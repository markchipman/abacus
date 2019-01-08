using System;
using System.Collections.Generic;
using Abacus.Pricing.Data;
using Abacus.Pricing.Measures;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Calculators
{
    public class FixedCouponBondMeasuresCalculator : MeasuresCalculator<FixedCouponBond>
    {
        public FixedCouponBondMeasuresCalculator(MeasureCalculator<FixedCouponBond, PresentValue> presentValueCalculator)
            : base(presentValueCalculator)
        {
        }
    }
}
