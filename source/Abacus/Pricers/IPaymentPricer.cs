using System;
using Abacus.Domain.Core;

namespace Abacus.Pricers
{
    public interface IPaymentPricer
    {
        CurrencyAmount PresentValuePayment(DateTime valuationDate, Payment payment, DiscountFactors discountFactors);
    }
}