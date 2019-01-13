using System;
using Abacus.Domain;

namespace Abacus.Pricers
{

    public interface IPaymentPricer
    {
        CurrencyAmount PresentValue(Payment payment, DateTime valuationDate, DiscountFactors discountFactors);

        CurrencyAmount FutureValue(Payment payment, DateTime valuationDate);
    }
}
