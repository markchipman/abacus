using System;
using Abacus.Domain.Core;
using Abacus.Domain.Instruments;

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
