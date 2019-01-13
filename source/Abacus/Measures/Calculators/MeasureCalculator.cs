using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Calculators
{
    public abstract class MeasureCalculator<TTarget> : IMeasureCalculator<TTarget>
    {
        public abstract IEnumerable<MarketDataRequirement> GetRequirements(TTarget target, DateTime valuationDate);

        public abstract MeasureResult CalculateMeasure(TTarget target, DateTime valuationDate, IMarketData marketData);
    }
}
