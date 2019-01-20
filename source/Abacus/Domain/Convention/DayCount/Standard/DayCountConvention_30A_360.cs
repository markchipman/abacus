using System;

namespace Abacus.Domain
{
    internal sealed class DayCountConvention_30A_360 : DayCountConvention<DayCountConvention_30A_360>
    {
        public DayCountConvention_30A_360()
            : base("30A/360") // US30/60, Bond Basis
        {
        }

        public override decimal YearFraction(DateTime startDate, DateTime endDate, DateTime paymentDate)
        {
            var y1 = startDate.Year;
            var m1 = startDate.Month;
            var d1 = startDate.Day;

            var y2 = endDate.Year;
            var m2 = endDate.Month;
            var d2 = endDate.Day;

            if (d1 == 31)
            {
                d1 = 30;
            }
            if (d2 == 31 && d1 == 30)
            {
                d2 = 30;
            }

            var numerator = CalculateNumerator30360(y1, m1, d1, y2, m2, d2);
            var denominator = 360;

            var yearFraction = numerator / denominator;

            return yearFraction;
        }
    }
}
