using System;

namespace Abacus.Domain
{
    public sealed class IMMRollConvention : RollConvention<IMMRollConvention>
    {
        /// <summary>
        /// International Money Market roll convention.
        /// 
        /// Rolls dates to 3rd Wednesday of the current month.
        /// </summary>
        public IMMRollConvention()
            : base("IMM")
        {
        }

        public sealed override DateTime Roll(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 21);
            return date <= thirdWedOfMonth ? thirdWedOfMonth : date.AddDays(((int)DayOfWeek.Wednesday) - ((int)date.DayOfWeek) + 21);
        }
    }
}
