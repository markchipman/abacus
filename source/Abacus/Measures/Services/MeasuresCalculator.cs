using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Services
{
    public class MeasuresCalculator
    {
        private readonly MeasureCalculatorRegistry _registry;

        public MeasuresCalculator(MeasureCalculatorRegistry registry)
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        }

        public IEnumerable<object> MarketDataRequirements<TTarget>(DateTime valuationDate, TTarget target, params Measure[] measures)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (measures == null)
            {
                throw new ArgumentNullException(nameof(measures));
            }

            foreach (var measure in measures)
            {
                var calculator = _registry.Get(target, measure);
                yield return calculator.MarketDataRequirements(valuationDate, target);
            }
        }

        public IEnumerable<object> CalculateMeasures<TTarget>(DateTime valuationDate, IMarketData marketData, TTarget target, params Measure[] measures)
        {
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (measures == null)
            {
                throw new ArgumentNullException(nameof(measures));
            }

            foreach (var measure in measures)
            {
                var calculator = _registry.Get(target, measure);
                yield return calculator.CalculateMeasure(valuationDate, marketData, target);
            }
        }
    }
}
