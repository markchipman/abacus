using System;
using Abacus.Domain;

namespace Abacus.Pricers
{
    public interface IPaymentPricer
    {
        CurrencyAmount PresentValuePayment(DateTime valuationDate, Payment payment, DiscountFactors discountFactors);
        CurrencyAmount FutureValuePayment(DateTime valuationDate, Payment payment);
    }
}
