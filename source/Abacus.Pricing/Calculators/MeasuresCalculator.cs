using Abacus.Pricing.Data;
using Abacus.Pricing.Measures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Abacus.Pricing.Calculators
{
    public class MeasuresCalculator
    {
        private MeasureCalculatorRegistrar _registry;

        public MeasuresCalculator(MeasureCalculatorRegistrar registry)
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        }

        public IEnumerable<object> CalculateMeasures<TTarget>(DateTime valuationDate, MarketData marketData, TTarget target, params Measure[] measures)
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
