using System;

namespace Abacus.Domain
{
    public class DayCountConvention
    {
        public decimal CountDays(DateTime startDate, DateTime endDate)
        {
            return 360m;
        }

        public decimal CountYears(DateTime startDate, DateTime endDate)
        {
            return 1m;
        }
    }
}
