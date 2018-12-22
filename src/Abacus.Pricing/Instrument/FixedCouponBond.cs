
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

    public abstract class Resolvable<T> : IResolvable<T>
    {
        protected abstract T Resolve(IResolver resolver);

        protected abstract T ResolveOrDefault(IResolver resolver, T @default);

        T IResolvable<T>.Resolve(IResolver resolver)
        {
            return Resolve(resolver);
        }

        T IResolvable<T>.ResolveOrDefault(IResolver resolver, T @default)
        {
            return ResolveOrDefault(resolver, @default);
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