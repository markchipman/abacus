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

        public IEnumerable<MarketDataRequirement> GetRequirements<TTarget>(TTarget target, DateTime valuationDate, params MeasureType[] measureTypes)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (measureTypes == null)
            {
                throw new ArgumentNullException(nameof(measureTypes));
            }

            foreach (var measure in measureTypes)
            {
                var calculator = _registry.GetCalculator(target, measure);

                var requirements = calculator?.GetRequirements(target, valuationDate);
                if (requirements is null)
                {
                    continue;
                }

                foreach (var requirement in requirements)
                {
                    yield return requirement;
                }
            }
        }

        public IEnumerable<MeasureResult> CalculateMeasures<TTarget>(TTarget target, DateTime valuationDate, IMarketData marketData, params MeasureType[] measureTypes)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }
            if (measureTypes == null)
            {
                throw new ArgumentNullException(nameof(measureTypes));
            }

            foreach (var measureType in measureTypes)
            {
                var calculator = _registry.GetCalculator(target, measureType);

                var measureResult = calculator?.CalculateMeasure(target, valuationDate, marketData);
                if (measureResult is null)
                {
                    continue;
                }

                yield return measureResult;
            }
        }
    }
}
