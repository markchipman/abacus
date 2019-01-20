using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_IMM : RollConvention<RollConvention_IMM>
    {
        /// <summary>
        /// International Money Market roll convention.
        /// 
        /// Rolls dates to 3rd Wednesday of the current month.
        /// </summary>
        public RollConvention_IMM()
            : base("IMM")
        {
        }

        public override DateTime Roll(DateTime date)
        {
            var firstOfMonth = new DateTime(date.Year, date.Month, 1);
            var thirdWedOfMonth = firstOfMonth.AddDays(((int)DayOfWeek.Wednesday) - ((int)firstOfMonth.DayOfWeek) + 14);
            return date <= thirdWedOfMonth ? thirdWedOfMonth : date.AddDays(((int)DayOfWeek.Wednesday) - ((int)date.DayOfWeek) + 14);
        }
    }
}
