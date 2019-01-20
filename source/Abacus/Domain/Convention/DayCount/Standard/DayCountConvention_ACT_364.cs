using System;

namespace Abacus.Domain
{
    internal sealed class DayCountConvention_ACT_364 : DayCountConvention<DayCountConvention_ACT_364>
    {
        public DayCountConvention_ACT_364()
            : base("ACT/364")
        {
        }

        public override decimal YearFraction(DateTime startDate, DateTime endDate, DateTime paymentDate)
        {
            var numerator = (endDate - startDate).Days;
            var denominator = 364;

            var yearFraction = numerator / denominator;

            return yearFraction;
        }
    }
}
