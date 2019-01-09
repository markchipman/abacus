using System;
using System.Collections.Generic;
using System.Linq;
using Abacus.Pricing.Data;
using Abacus.Pricing.Measures;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Calculators
{
    public abstract class MeasuresCalculator<TTarget>
    {
        public MeasuresCalculator(params MeasureCalculator<TTarget>[] calculators)
        {
            if (calculators == null)
            {
                throw new ArgumentNullException(nameof(calculators));
            }

            Calculators = new Dictionary<Measure, MeasureCalculator<TTarget>>(calculators.ToDictionary(x => x.Measure));
        }

        public MeasuresCalculator(IDictionary<Measure, MeasureCalculator<TTarget>> measureCalculators)
        {
            if (measureCalculators == null)
            {
                throw new ArgumentNullException(nameof(measureCalculators));
            }

            Calculators = new Dictionary<Measure, MeasureCalculator<TTarget>>(measureCalculators);
        }

        public Type TargetType => typeof(TTarget);

        public IReadOnlyList<Measure> Measures { get; }

        protected IReadOnlyDictionary<Measure, MeasureCalculator<TTarget>> Calculators { get; }

        public IEnumerable<object> CalculateMeasures(DateTime valuationDate, MarketData marketData, TTarget target, params Measure[] measures)
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
                if (Calculators.TryGetValue(measure, out MeasureCalculator<TTarget> calculator))
                {
                    var result = calculator.CalculateMeasure(valuationDate, marketData, target);
                    yield return result; // TODO result obj
                }
            }
        }
    }
}
