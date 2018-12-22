
using Abacus.Core.Resolvable;

namespace Abacus.Pricing.Instrument
{
    public static class Test
    {
        public static void Main(string[] args)
        {
            new FixedCouponBond();
        }
    }

    public class FixedCouponBond : Resolvable<ResolvedFixedCouponBond>
    {
        protected override ResolvedFixedCouponBond Resolve(IResolver resolver)
        {
            return new ResolvedFixedCouponBond(); // TODO
        }

        protected override ResolvedFixedCouponBond ResolveOrDefault(IResolver resolver, ResolvedFixedCouponBond @default)
        {
            return new ResolvedFixedCouponBond(); // TODO
        }
    }

    public class ResolvedFixedCouponBond
    {
    }
}