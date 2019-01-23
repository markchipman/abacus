using System;

namespace Abacus.Domain
{
    public class TimeDurationFrequency : Frequency
    {
        public TimeDurationFrequency(TimeDuration duration)
        {
            if (duration is null)
            {
                throw new ArgumentNullException(nameof(duration));
            }

            Duration = duration;
        }

        public TimeDuration Duration { get; }

        public sealed override DateTime NextEventDate(DateTime date)
        {
            return date.AddYears(Duration.Years)
                       .AddMonths(Duration.Months)
                       .AddWeeks(Duration.Weeks)
                       .AddDays(Duration.Days)
                       .AddHours(Duration.Hours)
                       .AddSeconds(Duration.Seconds)
                       .AddMilliseconds(Duration.Milliseconds);
        }
    }
}
