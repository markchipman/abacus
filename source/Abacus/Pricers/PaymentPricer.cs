using System;
using Abacus.Domain.Core;

namespace Abacus.Pricers
{
    public class PaymentPricer
    {
        public CurrencyAmount PresentValuePayment(DateTime valuationDate, Payment payment, DiscountFactors discountFactors)
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
