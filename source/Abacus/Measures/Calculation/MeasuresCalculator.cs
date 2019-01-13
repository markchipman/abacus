using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Measures.Services;

namespace Abacus.Measures.Calculation
{

    public class MeasuresCalculator : IMeasuresCalculator
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

        public IEnumerable<MarketDataRequirement> GetRequirements<TTarget>(TTarget target, DateTime valuationDate, params MeasureType[] measures)
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
                var requirements = calculator.GetRequirements(target, valuationDate);
                foreach (var requirement in requirements)
                {
                    yield return requirement;
                }
            }
        }

        public IEnumerable<MeasureResult> CalculateMeasures<TTarget>(TTarget target, DateTime valuationDate, IMarketData marketData, params MeasureType[] measures)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }
            if (measures == null)
            {
                throw new ArgumentNullException(nameof(measures));
            }

            foreach (var measure in measures)
            {
                var calculator = _registry.GetCalculator(target, measure);
                yield return calculator.CalculateMeasure(target, valuationDate, marketData);
            }
        }
    }
}
