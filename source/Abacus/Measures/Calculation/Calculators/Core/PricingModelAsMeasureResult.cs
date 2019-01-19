
using System;
using System.Collections.Generic;
using System.Linq;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Calculators
{
    public class PricingModelAsMeasureResult<TTarget> : IMeasureCalculator<TTarget>
    {
        public static readonly IMeasureCalculator<TTarget> Instance = new PricingModelAsMeasureResult<TTarget>();

        static PricingModelAsMeasureResult()
        {
        }

        public IEnumerable<MarketDataRequirement> GetRequirements(TTarget target, DateTime valuationDate)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return Enumerable.Empty<MarketDataRequirement>();
        }

        public MeasureResult CalculateMeasure(TTarget target, DateTime valuationDate, IMarketData marketData)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }

            return new MeasureResult(StandardMeasure.PricingModel, target);
        }
    }
}
