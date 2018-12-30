using Abacus.Pricing.Models;
using System;

namespace Abacus.Pricing.Pricer
{
    public class PaymentPricer
    {
        public CurrencyAmount PresentValuePayment(DateTime valuationDate, Payment payment, DayCountConvention dayCountConvention, DiscountFactors discountFactors)
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

            var discountFactor = discountFactors.GetDiscountFactor(payment.PaymentDate, dayCountConvention);
            var pvPayment = payment.Amount * discountFactor;

            return pvPayment;
        }
    }

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

            var pvNominalPayment = paymentPricer.PresentValuePayment(valuationDate, bond.NominalPayment, bond.DayCountConvention, discountFactors);

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
                var pvCouponPayment = paymentPricer.PresentValuePayment(valuationDate, period.GetPayment(), bond.DayCountConvention, discountFactors);
                pvCouponPayments += pvCouponPayment;
            }

            return pvCouponPayments;
        }
    }

    public interface IMarketData
    {
        T GetMarketData<T>();
    }

    public interface IRequireMarketData
    {
    }
}
