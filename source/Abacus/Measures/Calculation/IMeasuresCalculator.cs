using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Calculation
{
    public interface IMeasuresCalculator
    {
        IEnumerable<MarketDataRequirement> GetRequirements<TTarget>(DateTime valuationDate, TTarget target, params MeasureType[] measures);
        IEnumerable<MeasureResult> CalculateMeasures<TTarget>(DateTime valuationDate, IMarketData marketData, TTarget target, params MeasureType[] measures);
    }
}
