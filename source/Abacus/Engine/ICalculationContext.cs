using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Measures;
using Abacus.Measures.Calculation;

namespace Abacus.Engine
{
    public interface ICalculationContext
    {
        IEnumerable<MarketDataRequirement> GetRequirements(IMeasuresCalculator calculator, DateTime valuationDate, params MeasureType[] measureTypes);

        IEnumerable<MeasureResult> CalculateMeasures(IMeasuresCalculator calculator, DateTime valuationDate, IMarketData marketData, params MeasureType[] measureTypes);
    }
}
