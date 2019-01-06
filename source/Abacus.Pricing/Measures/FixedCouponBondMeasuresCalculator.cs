using System;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures
{

    public class FixedCouponBondMeasuresCalculator : IInstrumentMeasuresCalculator<FixedCouponBond>
    {
        public object CalculateMeasures(DateTime valuationDate, FixedCouponBond instrument, params Measure[] measures)
        {
            throw new NotImplementedException();
        }
    }
}
