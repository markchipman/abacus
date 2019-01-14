using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Calculators
{
    public interface IMeasureCalculator<TTarget>
    {
        IEnumerable<MarketDataRequirement> GetRequirements(TTarget target, DateTime valuationDate);

        MeasureResult CalculateMeasure(TTarget target, DateTime valuationDate, IMarketData marketData);
    }
}
