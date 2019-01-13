using System.Collections.Generic;
using System.Linq;

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

            var periods = new List<RatePaymentPeriod>();
            var periodDateItems = scheduleInfo.Frequency.GenerateTimePeriods(scheduleInfo.StartDate, scheduleInfo.EndDate).ToList();
            foreach (var periodDateItem in periodDateItems)
            {
                var periodStartDate = periodDateItem.Item1;
                var periodEndDate = periodDateItem.Item2;
                var periodAdjustedStartDate = scheduleInfo.RollConvention.Adjust(periodStartDate);
                var periodAdjustedEndDate = scheduleInfo.RollConvention.Adjust(periodEndDate);

                var period = new RatePaymentPeriod(periodStartDate, periodEndDate, periodAdjustedStartDate, periodAdjustedEndDate, periodEndDate, periodAdjustedEndDate, notional, rate);
                periods.Add(period);
            }

            return new RatePaymentSchedule(periods);
        }
    }
}
