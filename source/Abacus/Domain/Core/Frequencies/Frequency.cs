using System;
using System.Collections.Generic;

namespace Abacus.Domain
{
    public abstract class Frequency
    {
        public abstract DateTime NextEventDate(DateTime date);

        public virtual IEnumerable<Tuple<DateTime, DateTime>> GenerateTimePeriods(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException(nameof(startDate) + " cannot be after " + nameof(endDate));
            }

            var periodStartDate = startDate;
            do
            {
                var periodEndDate = new DateTime(Math.Min(NextEventDate(periodStartDate).Ticks, endDate.Ticks));
                yield return Tuple.Create(periodStartDate, periodEndDate);

                // next
                periodStartDate = periodEndDate;
            }
            while (periodStartDate < endDate);
        }
    }
}
