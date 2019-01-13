using System.Collections.Generic;

namespace Abacus.Domain
{
    public class RatePaymentSchedule : Schedule<RatePaymentPeriod>
    {
        public RatePaymentSchedule(IEnumerable<RatePaymentPeriod> periods)
            : base(periods)
        {
        }

        public static Schedule<RatePaymentPeriod> GenerateFixedRateSchedule(ScheduleInfo scheduleInfo, CurrencyAmount notional, Rate rate)
        {
            if (scheduleInfo == null)
            {
                throw new System.ArgumentNullException(nameof(scheduleInfo));
            }
            if (notional == null)
            {
                throw new System.ArgumentNullException(nameof(notional));
            }

            var periods = new List<RatePaymentPeriod>
            {
                new RatePaymentPeriod(scheduleInfo.StartDate, scheduleInfo.EndDate, scheduleInfo.EndDate, notional, rate)
            };

            return new RatePaymentSchedule(periods);
        }
    }
}
