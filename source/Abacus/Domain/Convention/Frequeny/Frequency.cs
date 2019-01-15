using System;
using System.Collections.Generic;
using Abacus.Enums;

namespace Abacus.Domain
{
    public abstract class Frequency<TSelf> : Frequency where TSelf : Frequency<TSelf>, new()
    {
        public static readonly TSelf Instance = new TSelf();

        protected Frequency(string id, TimeDuration periodDuration)
            : base(id, periodDuration)
        {
        }
    }

    public abstract class Frequency : Enumeration<string>
    {
        protected Frequency(string id, TimeDuration periodDuration)
            : base(id)
        {
            if (periodDuration is null)
            {
                throw new ArgumentNullException(nameof(periodDuration));
            }

            PeriodDuration = periodDuration;
        }

        public TimeDuration PeriodDuration { get; }

        public virtual DateTime NextEventDate(DateTime date)
        {
            return date.AddYears(PeriodDuration.Years)
                       .AddMonths(PeriodDuration.Months)
                       .AddDays(PeriodDuration.Days)
                       .AddHours(PeriodDuration.Hours)
                       .AddSeconds(PeriodDuration.Seconds)
                       .AddMilliseconds(PeriodDuration.Milliseconds);
        }

        public virtual IEnumerable<TimePeriod> GenerateTimePeriods(DateTime startDate, DateTime endDate, bool endOnNextStartDate = false)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException(nameof(startDate) + " cannot be after " + nameof(endDate));
            }

            var periodStartDate = startDate;
            do
            {
                var nextEventDate = NextEventDate(periodStartDate);
                var periodEndDate = nextEventDate;
                if (!endOnNextStartDate)
                {
                    periodEndDate = periodEndDate.AddDays(-1);
                }
                periodEndDate = new DateTime(Math.Min(periodEndDate.Ticks, endDate.Ticks));
                yield return new TimePeriod(periodStartDate, periodEndDate);

                periodStartDate = nextEventDate;
            }
            while (periodStartDate < endDate);
        }
    }
}
