
using Abacus.Core.Resolvable;

namespace Abacus.Pricing.Instrument
{
    public class FixedCouponBond : Resolvable<ResolvedFixedCouponBond>
    {
        protected override ResolvedFixedCouponBond Resolve(IResolver resolver)
        {
            return new ResolvedFixedCouponBond(); // TODO
        }
    }

    public class ResolvedFixedCouponBond
    {
    }
}