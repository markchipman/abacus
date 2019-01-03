using System;

namespace Abacus.Pricing.Models
{
    public class DiscountFactors
    {
        private readonly DateTime valuationDate;
        private readonly Curve curve;

        public DiscountFactors(DateTime valuationDate, Curve curve)
        {
            this.valuationDate = valuationDate;
            this.curve = curve ?? throw new ArgumentNullException(nameof(curve));
        }

        public decimal GetDiscountFactor(DateTime date, DayCountConvention dayCountConvention)
        {
            var years = dayCountConvention.CountYears(valuationDate, date);
            var discountFactor = GetDiscountFactor(years);
            return discountFactor;
        }

        public decimal GetDiscountFactor(decimal years)
        {
            var discountFactor = curve.Y(years);
            return discountFactor;
        }
    }
}
