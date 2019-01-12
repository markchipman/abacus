using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Calculators
{
    public abstract class MeasureCalculator<TTarget>
    {
        public abstract IEnumerable<MarketDataRequirement> GetRequirements(DateTime valuationDate, TTarget target);

        public abstract MeasureResult CalculateMeasure(DateTime valuationDate, IMarketData marketData, TTarget target);
    }
}
