using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_EOM : RollConvention<RollConvention_EOM>
    {
        /// <summary>
        /// End of month roll convention.
        /// 
        /// Rolls date to end of month.
        /// </summary>
        public RollConvention_EOM()
            : base("EOM")
        {
        }

        public override DateTime Roll(DateTime date) => new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }
}
