using System;

namespace Abacus.Domain
{
    internal sealed class DayCountConvention_ACT_364 : DayCountConvention
    {
        public override decimal YearFraction(DateTime startDate, DateTime endDate)
        {
            var numerator = (endDate - startDate).Days;
            var denominator = 364;

            var yearFraction = numerator / denominator;

            return yearFraction;
        }
    }
}
