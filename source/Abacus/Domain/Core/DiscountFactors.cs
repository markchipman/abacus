using System;

namespace Abacus.Domain.Core
{
    public class DiscountFactors
    {
        private readonly Curve _curve;
        private readonly DayCountConvention _dayCountConvention;
        private readonly DateTime _valuationDate;

        public DiscountFactors(DateTime valuationDate, DayCountConvention dayCountConvention, Curve curve)
        {
            if (dayCountConvention == null)
            {
                throw new ArgumentNullException(nameof(dayCountConvention));
            }
            if (curve == null)
            {
                throw new ArgumentNullException(nameof(curve));
            }

            _valuationDate = valuationDate;
            _dayCountConvention = dayCountConvention;
            _curve = curve;
        }

        public decimal GetDiscountFactor(DateTime date)
        {
            var countDays = _dayCountConvention.CountDays(_valuationDate, date);
            var discountFactor = GetDiscountFactor(countDays);
            return discountFactor;
        }

        public decimal GetDiscountFactor(decimal days)
        {
            var discountFactor = _curve.Y(days);
            return discountFactor;
        }
    }
}
