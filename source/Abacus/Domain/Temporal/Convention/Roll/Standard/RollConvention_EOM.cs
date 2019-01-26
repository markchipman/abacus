using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_EOM : RollConvention
    {
        public override bool IsEOM => true;

        protected override bool NeedsRoll(DateTime date)
        {
            var notEndOfMonth = date.Day != DateTime.DaysInMonth(date.Year, date.Month);
            return notEndOfMonth;
        }

        protected override DateTime DoRoll(DateTime date)
        {
            var dateNextMonth = date.AddMonths(1);
            var nextMonthLastDay = new DateTime(dateNextMonth.Year, dateNextMonth.Month, DateTime.DaysInMonth(dateNextMonth.Year, dateNextMonth.Month));
            return nextMonthLastDay;
        }
    }
}
