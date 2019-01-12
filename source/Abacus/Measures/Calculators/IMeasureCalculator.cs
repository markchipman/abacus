﻿using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;

namespace Abacus.Measures.Calculators
{
    public interface IMeasureCalculator<TTarget>
    {
        IEnumerable<MarketDataRequirement> GetRequirements(DateTime valuationDate, TTarget target);
        MeasureResult CalculateMeasure(DateTime valuationDate, IMarketData marketData, TTarget target);
    }
}