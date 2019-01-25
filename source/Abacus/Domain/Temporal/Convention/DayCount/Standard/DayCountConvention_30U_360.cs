using System;

namespace Abacus.Domain
{
    internal sealed class DayCountConvention_30U_360 : DayCountConvention
    {
        public override decimal YearFraction(DateTime startDate, DateTime endDate)
        {
            var y1 = startDate.Year;
            var m1 = startDate.Month;
            var d1 = startDate.Day;

            var y2 = endDate.Year;
            var m2 = endDate.Month;
            var d2 = endDate.Day;

            if (startDate.IsLastDayOfFebruary())
            {
                d1 = 30;
                if (endDate.IsLastDayOfFebruary())
                {
                    d2 = 30;
                }
            }
            if (d1 == 31)
            {
                d1 = 30;
            }
            if (d2 == 31 && d1 == 30)
            {
                d2 = 30;
            }

            var numerator = Days30360(y1, m1, d1, y2, m2, d2);
            var denominator = 360;

            var yearFraction = numerator / denominator;

            return yearFraction;
        }
    }
}
