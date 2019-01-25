using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_EOM : RollConvention
    {
        public override bool IsEOM => true;

        public override bool Matches(DateTime date)
        {
            var isEndOfMonth = date.Day == DateTime.DaysInMonth(date.Year, date.Month);
            return isEndOfMonth;
        }

        public override DateTime Roll(DateTime date)
        {
            var endOfMonth = Matches(date) ? date : RollForward(date);
            return endOfMonth;
        }

        public override DateTime RollForward(DateTime date)
        {
            var dateNextMonth = date.AddMonths(1);
            var nextMonthLastDay = new DateTime(dateNextMonth.Year, dateNextMonth.Month, DateTime.DaysInMonth(dateNextMonth.Year, dateNextMonth.Month));
            return nextMonthLastDay;
        }

        public override DateTime RollBackward(DateTime date)
        {
            var dateLastMonth = date.AddMonths(-1);
            var lastMonthLastDay = new DateTime(dateLastMonth.Year, dateLastMonth.Month, DateTime.DaysInMonth(dateLastMonth.Year, dateLastMonth.Month));
            return lastMonthLastDay;
        }
    }
}
