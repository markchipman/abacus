using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Domain;
using Abacus.Measures;
using Abacus.Measures.Services;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebAPI.Controllers
{
    [Route("api/calculate")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        [HttpGet("price")]
        public IActionResult GetPrice()
        {
            Instrument instrument = new FixedCouponBond();
            var valuationDate = DateTime.Today;
            var measures = new[] { StandardMeasures.PresentValue };

            var marketData = new MarketData();
            var calculatorRegistry = new MeasureCalculatorRegistrar();
            var calculator = new MeasuresCalculator(calculatorRegistry);

            var calculationContext = new CalculationContext(valuationDate, marketData, calculator, measures);

            instrument.ProvideContext(calculationContext);

            var results = calculationContext.Calculate();

            return Ok();
        }
    }

    public class CalculationContext : IAcceptContext<Instrument>
    {
        private readonly DateTime valuationDate;
        private readonly IMarketData marketData;
        private readonly MeasuresCalculator calculator;
        private readonly Measure[] measures;

        private readonly IList<Func<object>> calculations = new List<Func<object>>();

        public CalculationContext(DateTime valuationDate, IMarketData marketData, MeasuresCalculator calculator, params Measure[] measures)
        {
            this.valuationDate = valuationDate;
            this.marketData = marketData ?? throw new ArgumentNullException(nameof(marketData));
            this.calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            this.measures = measures ?? throw new ArgumentNullException(nameof(measures));
        }

        public void AcceptContext<T>(T target) where T : Instrument
        {
            calculations.Add(() => calculator.CalculateMeasures(valuationDate, marketData, target, measures));
        }

        public IEnumerable<object> Calculate()
        {
            foreach (var calculation in calculations)
            {
                var result = calculation();
                yield return result;
            }
        }
    }
}
