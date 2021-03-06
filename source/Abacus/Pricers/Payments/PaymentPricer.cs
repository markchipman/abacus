﻿using System;
using Abacus.Domain;

namespace Abacus.Pricers
{
    public class PaymentPricer : IPaymentPricer
    {
        public static readonly IPaymentPricer Instance = new PaymentPricer();

        static PaymentPricer()
        {
        }

        public CurrencyAmount PresentValue(Payment payment, DateTime valuationDate, DiscountFactors discountFactors)
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

        public CurrencyAmount FutureValue(Payment payment, DateTime valuationDate)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            if (payment.ExDate <= valuationDate)
            {
                return payment.Amount * 0;
            }
            if (payment.PaymentDate < valuationDate)
            {
                return payment.Amount * 0;
            }

            return payment.Amount;
        }
    }
}
