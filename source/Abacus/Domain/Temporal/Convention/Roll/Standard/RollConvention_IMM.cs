using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_IMM : RollConvention
    {
        public override bool IsEOM => false;

        public override bool Matches(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 14);
            var isThirdWedOfMonth = date == thirdWedOfMonth;
            return isThirdWedOfMonth;
        }

        public override DateTime Roll(DateTime date)
        {
            var thirdWedOfMonth = Matches(date) ? date : RollForward(date);
            return thirdWedOfMonth;
        }

        public override DateTime RollForward(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 14);
            var nextThirdWedOfMonth = date < thirdWedOfMonth ? thirdWedOfMonth : date.AddDays(((int)DayOfWeek.Wednesday) - ((int)date.DayOfWeek) + 14);
            return nextThirdWedOfMonth;
        }

        public override DateTime RollBackward(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 14);
            var previousThirdWedOfMonth = date > thirdWedOfMonth ? thirdWedOfMonth : RollForward(date.AddMonths(-1));
            return previousThirdWedOfMonth;
        }
    }
}
