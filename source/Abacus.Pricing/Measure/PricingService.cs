using System;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measure
{
    public class MeasureCalculationService
    {
        public void CalculateMeasures(DateTime valuationDate, FixedCouponBond instrument, params Measure[] measures)
        {
            throw new NotImplementedException();
        }
    }

    public enum Measure
    {
        PresentValue
    }
}
