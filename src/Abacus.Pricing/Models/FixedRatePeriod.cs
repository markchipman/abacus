using System;

namespace Abacus.Pricing.Models
{
    public class FixedRatePeriod
    {
        public DateTime PaymentDate { get; }

        public CurrencyAmount Notional { get; }

        public decimal Rate { get; }

        public DateTime? ExDate { get; }

        public bool HasExDate
        {
            get { return ExDate.HasValue; }
        }

        public Payment GetPayment()
        {
            return new Payment(PaymentDate, new CurrencyAmount(Notional.Value * Rate, Notional.Currency), ExDate);
        }
    }
}