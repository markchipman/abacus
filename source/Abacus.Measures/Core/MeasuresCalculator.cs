using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Measures.Services;

namespace Abacus.Measures
{
    public class MeasuresCalculator
    {
        private readonly MeasureCalculatorRegistrar _registry;

        public MeasuresCalculator(MeasureCalculatorRegistrar registry)
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
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
