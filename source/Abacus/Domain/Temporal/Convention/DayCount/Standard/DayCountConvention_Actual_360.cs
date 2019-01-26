using System;

namespace Abacus.Domain
{
    internal sealed class DayCountConvention_Actual_360 : DayCountConvention
    {
        public override decimal YearFraction(DateTime startDate, DateTime endDate)
        {
            var numerator = (endDate - startDate).Days;
            var denominator = 360;

            var yearFraction = numerator / denominator;

            return yearFraction;
        }
    }
}
