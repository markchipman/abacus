using System;
using System.Collections.Generic;

namespace Abacus.Pricing.Models
{
    public class DiscountFactors
    {
        private readonly DateTime valuationDate;
        private readonly DayCountConvention dayCountConvention;
        private readonly IReadOnlyDictionary<decimal, decimal> discountFactorDict;

        public DiscountFactors(DateTime valuationDate, DayCountConvention dayCountConvention, IReadOnlyDictionary<decimal, decimal> discountFactorDict)
        {
            this.valuationDate = valuationDate;
            this.dayCountConvention = dayCountConvention ?? throw new ArgumentNullException(nameof(dayCountConvention));
            this.discountFactorDict = discountFactorDict ?? throw new ArgumentNullException(nameof(discountFactorDict));
        }

        public decimal GetDiscountFactor(DateTime date)
        {
            var yearFraction = dayCountConvention.RelativeYearFraction(valuationDate, date);
            var discountFactor = GetDiscountFactor(yearFraction);
            return discountFactor;
        }

        public decimal GetDiscountFactor(decimal yearFraction)
        {
            var discountFactor = discountFactorDict[yearFraction];
            return discountFactor;
        }
    }

    public class Curve
    {
    }
}