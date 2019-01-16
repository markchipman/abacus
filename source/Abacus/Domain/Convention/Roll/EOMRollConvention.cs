using System;

namespace Abacus.Domain
{
    public sealed class EOMRollConvention : RollConvention<EOMRollConvention>
    {
        /// <summary>
        /// End of month roll convention.
        /// 
        /// Rolls date to end of month.
        /// </summary>
        public EOMRollConvention()
            : base("EOM")
        {
        }

        public sealed override DateTime Roll(DateTime date) => new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }
}
