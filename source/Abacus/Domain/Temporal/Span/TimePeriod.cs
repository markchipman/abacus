using System;
using System.Collections.Generic;
using Abacus.Debugging;

namespace Abacus.Domain
{
    public class TimePeriod
    {
        public TimePeriod(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; }

        public DateTime End { get; }

        public override string ToString()
        {
            return Start.DebugToStringDateRange(End);
        }

        public static IEnumerable<TimePeriod> Generate(DateTime startDate, DateTime endDate, Frequency frequency, bool endOnNextStartDate = false)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException(nameof(startDate) + " cannot be after " + nameof(endDate));
            }

            var periodStartDate = startDate;

            do
            {
                var nextEvent = frequency.Next(periodStartDate);
                if (nextEvent is null || nextEvent == periodStartDate)
                {
                    yield break;
                }
                var nextEventDate = nextEvent.Value;

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
