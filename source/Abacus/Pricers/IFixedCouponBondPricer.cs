using System;
using Abacus.Domain;

namespace Abacus.Pricers
{
    public interface IFixedCouponBondPricer
    {
        CurrencyAmount PresentValue(FixedCouponBond bond, DateTime valuationDate, DiscountFactors discountFactors);

        CurrencyAmount FutureValue(FixedCouponBond bond, DateTime valuationDate);
    }
}
