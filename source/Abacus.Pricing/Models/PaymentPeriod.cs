using System;

namespace Abacus.Pricing.Models
{
    public class PaymentPeriod : Period
    {
        public DateTime PaymentDate { get; }

        public DateTime? ExDate { get; }

        public bool HasExDate
        {
            get { return ExDate.HasValue; }
        }

        public CurrencyAmount Notional { get; }

        public virtual Payment GetPayment()
        {
            return new Payment(PaymentDate, Notional, ExDate);
        }
    }
}