using System;

namespace Abacus.Domain.Core
{
    public class DiscountFactors
    {
        private readonly Curve curve;
        private readonly DayCountConvention dayCountConvention;
        private readonly DateTime valuationDate;

        public DiscountFactors(DateTime valuationDate, DayCountConvention dayCountConvention, Curve curve)
        {
            this.valuationDate = valuationDate;
            this.dayCountConvention = dayCountConvention ?? throw new ArgumentNullException(nameof(dayCountConvention));
            this.curve = curve ?? throw new ArgumentNullException(nameof(curve));
        }

        public decimal GetDiscountFactor(DateTime date)
        {
            var countDays = dayCountConvention.CountDays(valuationDate, date);
            var discountFactor = GetDiscountFactor(countDays);
            return discountFactor;
        }

        public decimal GetDiscountFactor(decimal days)
        {
            var discountFactor = curve.Y(days);
            return discountFactor;
        }
    }
}
