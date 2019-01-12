using System;
using Abacus.Domain.Core;
using Abacus.Domain.Instruments;

namespace Abacus.Pricers
{
    public class FixedCouponBondPricer : IFixedCouponBondPricer
    {
        public static readonly IFixedCouponBondPricer Instance = new FixedCouponBondPricer();

        private readonly IPaymentPricer _paymentPricer;

        static FixedCouponBondPricer()
        {
        }

        public FixedCouponBondPricer()
            : this(PaymentPricer.Instance)
        {
        }

        public FixedCouponBondPricer(IPaymentPricer paymentPricer)
        {
            if (paymentPricer == null)
            {
                throw new ArgumentNullException(nameof(paymentPricer));
            }

            _paymentPricer = paymentPricer;
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

        public CurrencyAmount FutureValue(DateTime valuationDate, FixedCouponBond bond)
        {
            if (bond == null)
            {
                throw new ArgumentNullException(nameof(bond));
            }

            var fvNominal = FutureValueNominalPayment(valuationDate, bond);
            var fvCoupons = FutureValueCouponPayments(valuationDate, bond);

            var fvTotal = fvNominal + fvCoupons;

            return fvTotal;
        }

        public CurrencyAmount FutureValueNominalPayment(DateTime valuationDate, FixedCouponBond bond)
        {
            if (bond == null)
            {
                throw new ArgumentNullException(nameof(bond));
            }

            return bond.NominalPayment.Amount;
        }

        public CurrencyAmount FutureValueCouponPayments(DateTime valuationDate, FixedCouponBond bond)
        {
            if (bond == null)
            {
                throw new ArgumentNullException(nameof(bond));
            }

            var fvCouponPayments = bond.Notional * 0;

            foreach (var period in bond.CouponSchedule)
            {
                var fvCouponPayment = _paymentPricer.FutureValuePayment(valuationDate, period.GetPayment());
                fvCouponPayments += fvCouponPayment;
            }

            return fvCouponPayments;
        }
    }
}
