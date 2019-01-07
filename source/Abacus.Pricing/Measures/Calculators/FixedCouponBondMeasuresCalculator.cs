using System;
using System.Collections.Generic;
using Abacus.Pricing.Data;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures.Calculators
{
    public class FixedCouponBondMeasuresCalculator : MeasuresCalculator<FixedCouponBond>
    {
        public FixedCouponBondMeasuresCalculator(MeasureCalculator<FixedCouponBond, PresentValue> presentValueCalculator)
            : base(presentValueCalculator)
        {
        }

        public override object CalculateMeasures(DateTime valuationDate, MarketData marketData, FixedCouponBond instrument, params Measure[] measures)
        {
            throw new NotImplementedException();
        }
    }
}
