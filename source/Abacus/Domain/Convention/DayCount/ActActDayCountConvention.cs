using System;

namespace Abacus.Domain
{
    public sealed class ActActDayCountConvention : DayCountConvention<ActActDayCountConvention>
    {
        public ActActDayCountConvention()
            : base("ACT/ACT")
        {
        }

        public sealed override decimal CountDays(DateTime startDate, DateTime endDate)
        {
            return Convert.ToDecimal((startDate - endDate).TotalDays);
        }
    }
}
