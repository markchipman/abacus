using System;

namespace Abacus.Domain
{
    public class DiscountFactors
    {
        private readonly Curve _discountRates;
        private readonly DayCountConvention _dayCountConvention;
        private readonly DateTime _valuationDate;

        public DiscountFactors(DateTime valuationDate, DayCountConvention dayCountConvention, Curve discountRates)
        {
            if (dayCountConvention == null)
            {
                throw new ArgumentNullException(nameof(dayCountConvention));
            }
            if (discountRates == null)
            {
                throw new ArgumentNullException(nameof(discountRates));
            }

            _valuationDate = valuationDate;
            _dayCountConvention = dayCountConvention;
            _discountRates = discountRates;
        }

        public decimal GetDiscountFactor(DateTime date)
        {
            var discountFactor = GetDiscountFactor(1);
            return discountFactor;
        }

        public decimal GetDiscountFactor(decimal days)
        {
            var r = _discountRates.Y(days);
            var discountFactor = 1m / (1m + r);
            return discountFactor;
        }
    }
}
