using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_IMM : RollConvention
    {
        public override DateTime Roll(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 14);
            return date <= thirdWedOfMonth ? thirdWedOfMonth : date.AddDays(((int)DayOfWeek.Wednesday) - ((int)date.DayOfWeek) + 14);
        }
    }
}
