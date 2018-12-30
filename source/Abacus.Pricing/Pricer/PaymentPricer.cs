﻿using Abacus.Pricing.Models;
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
}
