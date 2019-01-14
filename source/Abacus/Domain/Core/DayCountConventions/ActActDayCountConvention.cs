using System;

namespace Abacus.Domain
{
    public class ActActDayCountConvention : DayCountConvention
    {
        public static readonly DayCountConvention Instance = new ActActDayCountConvention();

        static ActActDayCountConvention()
        {
        }

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
