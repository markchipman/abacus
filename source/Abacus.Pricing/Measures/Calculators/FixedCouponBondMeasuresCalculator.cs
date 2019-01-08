﻿using System;
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
    }
}
