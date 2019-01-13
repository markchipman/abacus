using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Calculation
{
    public interface IMeasuresCalculator
    {
        IEnumerable<MarketDataRequirement> GetRequirements<TTarget>(TTarget target, DateTime valuationDate, params MeasureType[] measures);

        IEnumerable<MeasureResult> CalculateMeasures<TTarget>(TTarget target, DateTime valuationDate, IMarketData marketData, params MeasureType[] measures);
    }
}
