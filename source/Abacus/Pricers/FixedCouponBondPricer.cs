using System;
using Abacus.Domain;

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

        public CurrencyAmount PresentValue(FixedCouponBond bond, DateTime valuationDate, DiscountFactors discountFactors)
        {
            if (bond == null)
            {
                throw new ArgumentNullException(nameof(bond));
            }
            if (discountFactors == null)
            {
                throw new ArgumentNullException(nameof(discountFactors));
            }

            var pvTotal = bond.Notional * 0;

            foreach (var period in bond.Schedule)
            {
                var pvPayment = _paymentPricer.PresentValue(period.GetPayment(), valuationDate, discountFactors);
                pvTotal += pvPayment;
            }

            return pvTotal;
        }

        public CurrencyAmount FutureValue(FixedCouponBond bond, DateTime valuationDate)
        {
            if (bond == null)
            {
                throw new ArgumentNullException(nameof(bond));
            }

            var fvTotal = bond.Notional * 0;

            foreach (var period in bond.Schedule)
            {
                var fvPayment = _paymentPricer.FutureValue(period.GetPayment(), valuationDate);
                fvTotal += fvPayment;
            }

            return fvTotal;
        }
    }
}
