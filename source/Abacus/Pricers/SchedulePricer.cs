using System;
using Abacus.Domain;

namespace Abacus.Pricers
{
    public class SchedulePricer : ISchedulePricer
    {
        public static readonly ISchedulePricer Instance = new SchedulePricer(PaymentPricer.Instance);

        private readonly IPaymentPricer _paymentPricer;

        static SchedulePricer()
        {
        }

        public SchedulePricer(IPaymentPricer paymentPricer)
        {
            if (paymentPricer == null)
            {
                throw new ArgumentNullException(nameof(paymentPricer));
            }

            _paymentPricer = paymentPricer;
        }

        public CurrencyAmount PresentValue<TPeriod>(Schedule<TPeriod> schedule, DateTime valuationDate, DiscountFactors discountFactors) where TPeriod : PaymentPeriod
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }
            if (discountFactors == null)
            {
                throw new ArgumentNullException(nameof(discountFactors));
            }

            throw new NotImplementedException();
        }

        public CurrencyAmount FutureValue<TPeriod>(Schedule<TPeriod> schedule, DateTime valuationDate) where TPeriod : PaymentPeriod
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            throw new NotImplementedException();
        }
    }
}
