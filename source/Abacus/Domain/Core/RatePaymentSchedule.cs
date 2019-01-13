using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Abacus.Domain
{
    public class RatePaymentSchedule : Schedule<RatePaymentPeriod>
    {
        public RatePaymentSchedule(IEnumerable<RatePaymentPeriod> periods)
            : base(periods)
        {
        }

        public static IReadOnlyList<RatePaymentPeriod> ExpandFixedRateSchedule(ScheduleInfo scheduleInfo, CurrencyAmount notional, Rate rate)
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

            return new ReadOnlyCollection<RatePaymentPeriod>(periods);
        }
    }
}
