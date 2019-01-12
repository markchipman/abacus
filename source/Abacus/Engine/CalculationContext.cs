using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Measures;
using Abacus.Measures.Calculation;

namespace Abacus.Engine
{
    public abstract class CalculationContext : ICalculationContext
    {
        public abstract IEnumerable<MarketDataRequirement> GetRequirements(MeasuresCalculator calculator, DateTime valuationDate, params MeasureType[] measures);

        public abstract IEnumerable<MeasureResult> CalculateMeasures(MeasuresCalculator calculator, DateTime valuationDate, IMarketData marketData, params MeasureType[] measures);
    }
}
