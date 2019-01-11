using System;
using System.Collections.Generic;
using System.Linq;
using Abacus.Data.MarketData;
using Abacus.Domain.Core;
using Abacus.Domain.Instruments;
using Abacus.Measures;
using Abacus.Measures.Services;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebAPI.Controllers
{
    [Route("api/calculate")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        [HttpGet("measures")]
        public IActionResult CalculateMeasures()
        {
            Instrument instrument = new FixedCouponBond();
            var valuationDate = DateTime.Today;
            var measures = new[] { StandardMeasures.PresentValue };

            var calculatorRegistry = new MeasureCalculatorRegistry();
            var calculator = new MeasuresCalculator(calculatorRegistry);

            var calculationContext = new CalculationContext(valuationDate, calculator, measures);

            instrument.ProvideContext(calculationContext);

            var marketDataRequirements = calculationContext.MarketDataRequirements().ToList();
            var marketData = new MarketData(); // using marketDataRequirements somehow

            var results = calculationContext.Calculate(marketData).ToList();

            return Ok();
        }
    }

    public class CalculationContext : IAcceptContext<Instrument>
    {
        private readonly IList<Func<IMarketData, object>> calculations = new List<Func<IMarketData, object>>();
        private readonly MeasuresCalculator calculator;

        private readonly IList<Func<object>> marketDataRequirements = new List<Func<object>>();
        private readonly Measure[] measures;
        private readonly DateTime valuationDate;

        public CalculationContext(DateTime valuationDate, MeasuresCalculator calculator, params Measure[] measures)
        {
            this.valuationDate = valuationDate;
            this.calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            this.measures = measures ?? throw new ArgumentNullException(nameof(measures));
        }

        public void AcceptContext<T>(T target) where T : Instrument
        {
            marketDataRequirements.Add(() => calculator.MarketDataRequirements(valuationDate, target, measures));
            calculations.Add(marketData => calculator.CalculateMeasures(valuationDate, marketData, target, measures));
        }

        public IEnumerable<object> MarketDataRequirements()
        {
            foreach (var marketDataRequirement in marketDataRequirements)
            {
                var result = marketDataRequirement();
                yield return result;
            }
        }

        public IEnumerable<object> Calculate(IMarketData marketData)
        {
            foreach (var calculation in calculations)
            {
                var result = calculation(marketData);
                yield return result;
            }
        }
    }
}
