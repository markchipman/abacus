using System;

namespace Abacus.Domain
{
    public sealed class DayCountConvention_ACT_360 : DayCountConvention<DayCountConvention_ACT_360>
    {
        public DayCountConvention_ACT_360()
            : base("ACT/360")
        {
        }

        public override decimal YearFraction(DateTime startDate, DateTime endDate, DateTime paymentDate)
        {
            var numerator = (endDate - startDate).Days;
            var denominator = 360;

            var yearFraction = numerator / denominator;

            return yearFraction;
        }
    }
}
