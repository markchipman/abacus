using System;
using Abacus.Domain;

namespace Abacus.Pricers
{
    public interface IFixedCouponBondPricer
    {
        CurrencyAmount PresentValue(DateTime valuationDate, FixedCouponBond bond, DiscountFactors discountFactors);
        CurrencyAmount PresentValueCouponPayments(DateTime valuationDate, FixedCouponBond bond, DiscountFactors discountFactors);
        CurrencyAmount PresentValueNominalPayment(DateTime valuationDate, FixedCouponBond bond, DiscountFactors discountFactors);

        CurrencyAmount FutureValue(DateTime valuationDate, FixedCouponBond bond);
        CurrencyAmount FutureValueCouponPayments(DateTime valuationDate, FixedCouponBond bond);
        CurrencyAmount FutureValueNominalPayment(DateTime valuationDate, FixedCouponBond bond);
    }
}
