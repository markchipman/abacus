﻿using System;

namespace Abacus.Domain
{
    public sealed class DayCountConvention_30EPLUS_360 : DayCountConvention<DayCountConvention_30EPLUS_360>
    {
        public DayCountConvention_30EPLUS_360()
            : base("30E+/360")

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
            if (d2 == 31)
            {
                var nextDay = endDate.AddDays(1);
                y2 = nextDay.Year;
                m2 = nextDay.Month;
                d2 = nextDay.Day;
            }

            var numerator = CalculateNumerator30360(y1, m1, d1, y2, m2, d2);
            var denominator = 360;

            var yearFraction = numerator / denominator;

            return yearFraction;
        }
    }
}
