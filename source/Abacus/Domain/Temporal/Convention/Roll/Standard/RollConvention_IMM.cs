using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_IMM : RollConvention
    {
        protected override bool NeedsRoll(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 14);
            var notThirdWedOfMonth = date != thirdWedOfMonth;
            return notThirdWedOfMonth;
        }

        protected override DateTime DoRoll(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 14);
            var nextThirdWedOfMonth = date < thirdWedOfMonth ? thirdWedOfMonth : date.AddDays(((int)DayOfWeek.Wednesday) - ((int)date.DayOfWeek) + 14);
            return nextThirdWedOfMonth;
        }
    }
}
