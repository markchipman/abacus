using System;

namespace Abacus.Domain
{
    public abstract class DayCountConvention
    {
        public abstract decimal YearFraction(DateTime startDate, DateTime endDate);

        protected static int Days30360(int y1, int m1, int d1, int y2, int m2, int d2)
        {
            var days = d2 - d1 + (30 * (m2 - m1)) + (360 * (y2 - y1));
            return days;
        }
    }
}
