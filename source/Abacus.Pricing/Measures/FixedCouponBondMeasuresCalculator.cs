using System;
using System.Collections.Generic;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures
{
    public class FixedCouponBondMeasuresCalculator : InstrumentMeasuresCalculator<FixedCouponBond>
    {
        public FixedCouponBondMeasuresCalculator(IDictionary<Measure, InstrumentMeasureCalculator<FixedCouponBond>> measureCalculators)
            : base(measureCalculators)
        {
        }

        public override object CalculateMeasures(DateTime valuationDate, FixedCouponBond instrument, params Measure[] measures)
        {
            throw new NotImplementedException();
        }
    }
}
