using System;
using System.Collections.Generic;
using System.Linq;
using Abacus.Context;
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

            var calculationContext = new CalculationContext(calculator);

            instrument.ProvideContext(calculationContext);

            var marketDataRequirements = calculationContext.MarketDataRequirements(valuationDate, measures).ToList();
            var marketData = new MarketData(); // created using market data requirements

            var results = calculationContext.Calculate(valuationDate, marketData, measures).ToList();

            return Ok();
        }
    }

    public class CalculationContext : IAcceptContext<Instrument>
    {
        private readonly IList<CalculationItem> _calculationItems = new List<CalculationItem>();
        private readonly MeasuresCalculator _calculator;

        public CalculationContext(MeasuresCalculator calculator)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }

            _calculator = calculator;
        }

        public void AcceptContext<TTarget>(TTarget target) where TTarget : Instrument
        {
            var calculationItem = new InstrumentCalculationItem<TTarget>(target, _calculator);
            _calculationItems.Add(calculationItem);
        }

        public IEnumerable<object> MarketDataRequirements(DateTime valuationDate, params MeasureType[] measures)
        {
            foreach (var calculationItem in _calculationItems)
            {
                var result = calculationItem.MarketDataRequirements(valuationDate, measures);
                yield return result;
            }
        }

        public IEnumerable<object> Calculate(DateTime valuationDate, IMarketData marketData, params MeasureType[] measures)
        {
            foreach (var calculationItem in _calculationItems)
            {
                var result = calculationItem.Calculate(valuationDate, marketData, measures);
                yield return result;
            }
        }
    }

    public class InstrumentCalculationItem<TTarget> : CalculationItem
    {
        private readonly TTarget _target;
        private readonly MeasuresCalculator _calculator;

        public InstrumentCalculationItem(TTarget target, MeasuresCalculator calculator)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }

            _target = target;
            _calculator = calculator;
        }

        public override object MarketDataRequirements(DateTime valuationDate, params MeasureType[] measures)
        {
            return _calculator.MarketDataRequirements(valuationDate, _target, measures);
        }


        public override object Calculate(DateTime valuationDate, IMarketData marketData, params MeasureType[] measures)
        {
            return _calculator.CalculateMeasures(valuationDate, marketData, _target, measures);
        }
    }

    public abstract class CalculationItem
    {
        public abstract object MarketDataRequirements(DateTime valuationDate, params MeasureType[] measures);

        public abstract object Calculate(DateTime valuationDate, IMarketData marketData, params MeasureType[] measures);
    }
}
