using Abacus.Pricing.Models;
using System;

namespace Abacus.Pricing.Pricer
{
    public class FixedCouponBondPricer
    {
        private readonly PaymentPricer paymentPricer = null;

        public FixedCouponBondPricer(PaymentPricer paymentPricer)
        {
            this.paymentPricer = paymentPricer ?? throw new ArgumentNullException(nameof(paymentPricer));
        }

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

            var pvNominalPayment = paymentPricer.PresentValuePayment(valuationDate, bond.NominalPayment, bond.ScheduleInfo.DayCountConvention, discountFactors);

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

            var pvCouponPayments = bond.Notional * 0;

            foreach (var period in bond.CouponSchedule)
            {
                var pvCouponPayment = paymentPricer.PresentValuePayment(valuationDate, period.GetPayment(), bond.ScheduleInfo.DayCountConvention, discountFactors);
                pvCouponPayments += pvCouponPayment;
            }

            return pvCouponPayments;
        }
    }
}
