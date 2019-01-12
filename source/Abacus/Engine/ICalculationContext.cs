using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Measures;
using Abacus.Measures.Calculation;

namespace Abacus.Engine
{
    public interface ICalculationContext
    {
        IEnumerable<MarketDataRequirement> GetRequirements(MeasuresCalculator calculator, DateTime valuationDate, params MeasureType[] measures);
        IEnumerable<MeasureResult> CalculateMeasures(MeasuresCalculator calculator, DateTime valuationDate, IMarketData marketData, params MeasureType[] measures);
    }
}
