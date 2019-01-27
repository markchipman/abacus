using System;

namespace Abacus.Domain
{
    internal sealed class DayRollConvention_EndOfMonth : DayRollConvention
    {
        public override bool IsEOM => true;

        public override bool IsRollDate(DateTime date)
        {
            var isEndOfMonth = date.Day == DateTime.DaysInMonth(date.Year, date.Month);
            return isEndOfMonth;
        }

        public override DateTime NextRoll(DateTime date)
        {
            var dateNextMonth = date.AddMonths(1);
            var nextMonthLastDay = new DateTime(dateNextMonth.Year, dateNextMonth.Month, DateTime.DaysInMonth(dateNextMonth.Year, dateNextMonth.Month));
            return nextMonthLastDay;
        }
    }
}
