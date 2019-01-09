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
