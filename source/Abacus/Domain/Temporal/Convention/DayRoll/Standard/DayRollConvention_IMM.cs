using System;

namespace Abacus.Domain
{
    internal sealed class DayRollConvention_IMM : DayRollConvention
    {
        public override bool IsRollDate(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 14);
            var isThirdWedOfMonth = date == thirdWedOfMonth;
            return isThirdWedOfMonth;
        }

        public override DateTime NextRoll(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 14);
            var nextThirdWedOfMonth = date < thirdWedOfMonth ? thirdWedOfMonth : date.AddDays(((int)DayOfWeek.Wednesday) - ((int)date.DayOfWeek) + 14);
            return nextThirdWedOfMonth;
        }
    }
}
