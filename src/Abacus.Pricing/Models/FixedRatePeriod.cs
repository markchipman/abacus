using System;

namespace Abacus.Pricing.Models
{
    public class FixedRatePeriod
    {
        public DateTime PaymentDate { get; }

        public DateTime? ExDate { get; }

        public CurrencyAmount Notional { get; }

        public decimal AnnualRate { get; }

        public decimal YearFraction { get; }

        public bool HasExDate
        {
            get { return ExDate.HasValue;  }
        }

        public Payment AsPayment()
        {
            return new Payment(PaymentDate, new CurrencyAmount(Notional.Value * AnnualRate * YearFraction, Notional.Currency), ExDate);
        }
    }
}