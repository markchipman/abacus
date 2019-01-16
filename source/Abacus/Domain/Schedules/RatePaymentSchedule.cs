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

            var timePeriods = scheduleInfo.Frequency.GenerateTimePeriods(scheduleInfo.StartDate, scheduleInfo.EndDate).ToList();
            foreach (var timePeriod in timePeriods)
            {
                var periodStartDate = timePeriod.Start;
                var periodEndDate = timePeriod.End;
                var periodAdjustedStartDate = scheduleInfo.RollConvention.Roll(periodStartDate);
                var periodAdjustedEndDate = scheduleInfo.RollConvention.Roll(periodEndDate);

                var period = new RatePaymentPeriod(periodStartDate, periodEndDate, periodAdjustedStartDate, periodAdjustedEndDate, periodEndDate, periodAdjustedEndDate, notional, rate);
                periods.Add(period);
            }

            return new RatePaymentSchedule(periods);
        }
    }
}
