using System;
using Abacus.Domain.Core;
using Abacus.Domain.Instruments;

namespace Abacus.Pricers
{
    public class FixedCouponBondPricer
    {
        private readonly PaymentPricer _paymentPricer;

        public FixedCouponBondPricer(PaymentPricer paymentPricer)
        {
            _paymentPricer = paymentPricer ?? throw new ArgumentNullException(nameof(paymentPricer));
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

            var pvNominalPayment = _paymentPricer.PresentValuePayment(valuationDate, bond.NominalPayment, discountFactors);

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
                var pvCouponPayment = _paymentPricer.PresentValuePayment(valuationDate, period.GetPayment(), discountFactors);
                pvCouponPayments += pvCouponPayment;
            }

            return pvCouponPayments;
        }
    }
}
