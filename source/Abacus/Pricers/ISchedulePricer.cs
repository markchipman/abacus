using System;
using Abacus.Domain;

namespace Abacus.Pricers
{
    public interface ISchedulePricer
    {
        CurrencyAmount PresentValue<TPeriod>(Schedule<TPeriod> schedule, DateTime valuationDate, DiscountFactors discountFactors) where TPeriod : PaymentPeriod;

        CurrencyAmount FutureValue<TPeriod>(Schedule<TPeriod> schedule, DateTime valuationDate) where TPeriod : PaymentPeriod;
    }
}
