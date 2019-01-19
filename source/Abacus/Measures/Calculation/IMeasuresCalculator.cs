using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Calculation
{
    public interface IMeasuresCalculator
    {
        IEnumerable<MarketDataRequirement> GetRequirements<TTarget>(TTarget target, DateTime valuationDate, params Measure[] measureTypes);

        IEnumerable<MeasureResult> CalculateMeasures<TTarget>(TTarget target, DateTime valuationDate, IMarketData marketData, params Measure[] measureTypes);
    }
}
