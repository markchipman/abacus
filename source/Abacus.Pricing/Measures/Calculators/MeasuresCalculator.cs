using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Abacus.Pricing.Data;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures.Calculators
{
    public abstract class MeasuresCalculator<TTarget>
    {
        public MeasuresCalculator(params MeasureCalculator<TTarget>[] measureCalculators)
        {
            if (measureCalculators == null)
            {
                throw new ArgumentNullException(nameof(measureCalculators));
            }

            MeasureCalculators = new Dictionary<Measure, MeasureCalculator<TTarget>>(measureCalculators.ToDictionary(x => x.Measure));
        }

        public MeasuresCalculator(IDictionary<Measure, MeasureCalculator<TTarget>> measureCalculators)
        {
            if (measureCalculators == null)
            {
                throw new ArgumentNullException(nameof(measureCalculators));
            }

            MeasureCalculators = new Dictionary<Measure, MeasureCalculator<TTarget>>(measureCalculators);
        }

        public Type TargetType => typeof(TTarget);

        public IReadOnlyList<Measure> Measures { get; }

        protected IReadOnlyDictionary<Measure, MeasureCalculator<TTarget>> MeasureCalculators { get; }

        public abstract object CalculateMeasures(DateTime valuationDate, MarketData marketData, TTarget target, params Measure[] measures);
    }
}
