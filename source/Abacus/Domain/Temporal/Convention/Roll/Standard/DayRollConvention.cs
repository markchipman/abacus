using System;

namespace Abacus.Domain
{
    public class DayRollConvention : RollConvention
    {
        private readonly int dayOfMonth;

        public DayRollConvention(int dayOfMonth)
        {
            this.dayOfMonth = dayOfMonth;
        }

        protected override bool NeedsRoll(DateTime date)
        {
            var notDayOfMonth = date.Day != dayOfMonth;
            return notDayOfMonth;
        }

        protected override DateTime DoRoll(DateTime date)
        {
            if (date.Day < dayOfMonth)
            {
                var daysToAdd = dayOfMonth - date.Day;
                var result = date.AddDays(daysToAdd);
                return result;
            }
            else
            {
                // TODO - checks for 28+ dayOfMonth values
                var firstOfMonth = new DateTime(date.Year, date.Month, 1);
                var firstOfNextMonth = firstOfMonth.AddMonths(1);
                var daysToAdd = dayOfMonth - firstOfNextMonth.Day;
                var result = date.AddDays(daysToAdd);
                return result;
            }
        }
    }
}
