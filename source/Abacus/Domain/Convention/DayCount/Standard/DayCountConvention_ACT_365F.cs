using System;

namespace Abacus.Domain
{
    internal sealed class DayCountConvention_ACT_365F : DayCountConvention<DayCountConvention_ACT_365F>
    {
        public DayCountConvention_ACT_365F()
            : base("ACT/365F") // ACT/365 Fixed
        {
        }

        public override decimal YearFraction(DateTime startDate, DateTime endDate, DateTime paymentDate)
        {
            var numerator = (endDate - startDate).Days;
            var denominator = 365;

            var yearFraction = numerator / denominator;

            return yearFraction;
        }
    }
}
