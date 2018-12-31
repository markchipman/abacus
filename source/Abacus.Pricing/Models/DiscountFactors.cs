using System;

namespace Abacus.Pricing.Models
{
    public class DiscountFactors
    {
        private readonly DateTime valuationDate;
        private readonly DayCountConvention dayCountConvention;
        private readonly Curve curve;

        public DiscountFactors(DateTime valuationDate, DayCountConvention dayCountConvention, Curve curve)
        {
            this.valuationDate = valuationDate;
            this.dayCountConvention = dayCountConvention ?? throw new ArgumentNullException(nameof(dayCountConvention));
            this.curve = curve ?? throw new ArgumentNullException(nameof(curve));
        }

        public decimal  GetDiscountFactor(DateTime date)
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