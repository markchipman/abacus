using System;
using System.Collections.Generic;
using Abacus.Enums;

namespace Abacus.Domain
{
    public abstract class Frequency<TSelf> : Frequency where TSelf : Frequency<TSelf>, new()
    {
        public static readonly TSelf Instance = new TSelf();

        protected Frequency(string id)
            : base(id)
        {
        }
    }

    public abstract class Frequency : Enumeration<string>
    {
        protected Frequency(string id)
            : base(id)
        {
        }

        public abstract DateTime NextEventDate(DateTime date);

        public virtual IEnumerable<Tuple<DateTime, DateTime>> GenerateTimePeriods(DateTime startDate, DateTime endDate, bool endOnNextStartDate = false)
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

                yield return Tuple.Create(periodStartDate, periodEndDate);

                periodStartDate = nextEventDate;
            }
            while (periodStartDate < endDate);
        }
    }
}
