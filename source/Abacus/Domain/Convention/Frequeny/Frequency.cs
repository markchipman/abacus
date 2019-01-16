using System;
using System.Collections.Generic;
using Abacus.Enums;

namespace Abacus.Domain
{
    public abstract class Frequency<TSelf> : Frequency where TSelf : Frequency<TSelf>, new()
    {
        public static readonly TSelf Instance = new TSelf();

        protected Frequency(string id, TimeDuration duration)
            : base(id, duration)
        {
        }
    }

    public abstract class Frequency : Enumeration<string>
    {
        protected Frequency(string id, TimeDuration duration)
            : base(id)
        {
            if (duration is null)
            {
                throw new ArgumentNullException(nameof(duration));
            }
            if (duration is null)
            {
                throw new ArgumentNullException(nameof(duration));
            }

            Duration = duration;
        }

        public TimeDuration Duration { get; }

        public DateTime NextEventDate(DateTime date)
        {
            return date.AddYears(Duration.Years)
                       .AddMonths(Duration.Months)
                       .AddDays(Duration.Weeks * 7)
                       .AddDays(Duration.Days)
                       .AddHours(Duration.Hours)
                       .AddSeconds(Duration.Seconds)
                       .AddMilliseconds(Duration.Milliseconds);
        }

        public IEnumerable<TimePeriod> GenerateTimePeriods(DateTime startDate, DateTime endDate, bool endOnNextStartDate = false)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException(nameof(startDate) + " cannot be after " + nameof(endDate));
            }

            var periodStartDate = startDate;

            do
            {
                var nextEventDate = NextEventDate(periodStartDate);
                if (nextEventDate == periodStartDate)
                {
                    yield break;
                }

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
