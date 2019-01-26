using System;
using System.Collections.Generic;

namespace Abacus.Domain
{
    public class TimePeriodGenerator
    {
        public IEnumerable<TimePeriod> GenerateTimePeriods(DateTime startDate, DateTime endDate, Frequency frequency, bool endOnNextStartDate = false)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException(nameof(startDate) + " cannot be after " + nameof(endDate));
            }

            var periodStartDate = startDate;

            do
            {
                var nextEventDate = frequency.Next(periodStartDate);
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
