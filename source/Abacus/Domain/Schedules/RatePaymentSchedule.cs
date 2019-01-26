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

            var periods = new List<RatePaymentPeriod>();

            var timePeriods = TimePeriod.Generate(scheduleInfo.StartDate, scheduleInfo.EndDate, scheduleInfo.Frequency);
            foreach (var timePeriod in timePeriods)
            {
                var periodStartDate = timePeriod.Start;
                var periodEndDate = timePeriod.End;
                var rolledStartDate = scheduleInfo.RollConvention.Roll(periodStartDate);
                var rolledEndDate = scheduleInfo.RollConvention.Roll(periodEndDate);

                var period = new RatePaymentPeriod(periodStartDate, periodEndDate, rolledStartDate, rolledEndDate, periodEndDate, rolledEndDate, notional, rate);
                periods.Add(period);
            }

            return new RatePaymentSchedule(periods);
        }
    }
}
