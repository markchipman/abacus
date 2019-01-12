using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Domain.Instruments;

namespace Abacus.Measures.Calculators
{
    public interface IFixedCouponBondPresentValueCalculator
    {
        MeasureResult CalculateMeasure(DateTime valuationDate, IMarketData marketData, FixedCouponBond target);
        IEnumerable<MarketDataRequirement> GetRequirements(DateTime valuationDate, FixedCouponBond target);
    }
}