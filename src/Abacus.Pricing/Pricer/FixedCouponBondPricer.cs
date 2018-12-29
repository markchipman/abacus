using Abacus.Pricing.Models;
using System;

namespace Abacus.Pricing.Pricer
{
    public class FixedCouponBondPricer
    {
        public CurrencyAmount PresentValue(DateTime valuationDate, FixedCouponBond bond, DiscountFactors discountFactors)
        {
            if (bond == null)
            {
                throw new ArgumentNullException(nameof(bond));
            }
            if (discountFactors == null)
            {
                throw new ArgumentNullException(nameof(discountFactors));
            }

            var pvNominal = PresentValueNominalPayment(valuationDate, bond, discountFactors);
            var pvCoupons = PresentValueCouponPayments(valuationDate, bond, discountFactors);

            var pvTotal = pvNominal + pvCoupons;

            return pvTotal;
        }

        public CurrencyAmount PresentValueNominalPayment(DateTime valuationDate, FixedCouponBond bond, DiscountFactors discountFactors)
        {
            if (bond == null)
            {
                throw new ArgumentNullException(nameof(bond));
            }
            if (discountFactors == null)
            {
                throw new ArgumentNullException(nameof(discountFactors));
            }

            var pvNominalPayment = PresentValuePayment(valuationDate, bond.NominalPayment, discountFactors);

            return pvNominalPayment;
        }

        public CurrencyAmount PresentValueCouponPayments(DateTime valuationDate, FixedCouponBond bond, DiscountFactors discountFactors)
        {
            if (bond == null)
            {
                throw new ArgumentNullException(nameof(bond));
            }
            if (discountFactors == null)
            {
                throw new ArgumentNullException(nameof(discountFactors));
            }

            var pvCouponPayments = new CurrencyAmount(0, bond.Currency);

            foreach (var period in bond.CouponSchedule)
            {
                var pvCouponPayment = PresentValuePayment(valuationDate, period.AsPayment(), discountFactors);
                pvCouponPayments += pvCouponPayment;
            }

            return pvCouponPayments;
        }

        private CurrencyAmount PresentValuePayment(DateTime valuationDate, Payment payment, DiscountFactors discountFactors)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            if (discountFactors == null)
            {
                throw new ArgumentNullException(nameof(discountFactors));
            }

            if (payment.ExDate <= valuationDate)
            {
                return payment.Amount * 0;
            }
            if (payment.PaymentDate < valuationDate)
            {
                return payment.Amount * 0;
            }

            var discountFactor = discountFactors.GetDiscountFactor(payment.PaymentDate);
            var pvPayment = payment.Amount * discountFactor;

            return pvPayment;
        }
    }
}
