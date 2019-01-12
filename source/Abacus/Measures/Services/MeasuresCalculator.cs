using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Services
{
    public class MeasuresCalculator
    {
        private readonly MeasureCalculationRegistry _registry;

        public MeasuresCalculator(MeasureCalculationRegistry registry)
        {
            if (registry == null)
            {
                throw new ArgumentNullException(nameof(registry));
            }

            _registry = registry;
        }

        public IEnumerable<object> MarketDataRequirements<TTarget>(DateTime valuationDate, TTarget target, params MeasureType[] measures)
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
                var calculator = _registry.GetCalculator(target, measure);
                yield return calculator.MarketDataRequirements(valuationDate, target);
            }
        }

        public IEnumerable<object> CalculateMeasures<TTarget>(DateTime valuationDate, IMarketData marketData, TTarget target, params MeasureType[] measures)
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
                var calculator = _registry.GetCalculator(target, measure);
                yield return calculator.CalculateMeasure(valuationDate, marketData, target);
            }
        }
    }
}
