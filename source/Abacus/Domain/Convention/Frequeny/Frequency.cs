using System;
using System.Collections.Generic;
using Abacus.Enums;

namespace Abacus.Domain
{
    public abstract class Frequency
    {
        public abstract DateTime NextEventDate(DateTime date);

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
