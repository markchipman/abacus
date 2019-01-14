using System;

namespace Abacus.Domain
{
    public class ActActDayCountConvention : DayCountConvention<ActActDayCountConvention>
    {
        public ActActDayCountConvention()
            : base("ACT/ACT")
        {
        }

        public override decimal CountDays(DateTime startDate, DateTime endDate)
        {
            return Convert.ToDecimal((startDate - endDate).TotalDays);
        }
    }
}
