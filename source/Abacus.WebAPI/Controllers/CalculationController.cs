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

            var calculatorRegistry = new MeasureCalculationRegistry();
            var calculator = new MeasuresCalculator(calculatorRegistry);

            var calculationContext = new CalculationContext(valuationDate, calculator, measures);

            instrument.ProvideContext(calculationContext);

            var marketDataRequirements = calculationContext.MarketDataRequirements().ToList();
            var marketData = new MarketData(); // created using market data requirements

            var results = calculationContext.Calculate(marketData).ToList();

            return Ok();
        }
    }

    public class CalculationContext : IAcceptContext<Instrument>
    {
        private readonly IList<Func<IMarketData, object>> _calculations = new List<Func<IMarketData, object>>();
        private readonly MeasuresCalculator _calculator;

        private readonly IList<Func<object>> _marketDataRequirements = new List<Func<object>>();
        private readonly MeasureType[] _measures;
        private readonly DateTime _valuationDate;

        public CalculationContext(DateTime valuationDate, MeasuresCalculator calculator, params MeasureType[] measures)
        {
            _valuationDate = valuationDate;
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _measures = measures ?? throw new ArgumentNullException(nameof(measures));
        }

        public void AcceptContext<T>(T target) where T : Instrument
        {
            _marketDataRequirements.Add(() => _calculator.MarketDataRequirements(_valuationDate, target, _measures));
            _calculations.Add(marketData => _calculator.CalculateMeasures(_valuationDate, marketData, target, _measures));
        }

        public IEnumerable<object> MarketDataRequirements()
        {
            foreach (var marketDataRequirement in _marketDataRequirements)
            {
                var result = marketDataRequirement();
                yield return result;
            }
        }

        public IEnumerable<object> Calculate(IMarketData marketData)
        {
            foreach (var calculation in _calculations)
            {
                var result = calculation(marketData);
                yield return result;
            }
        }
    }
}
