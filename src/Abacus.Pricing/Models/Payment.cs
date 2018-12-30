using System;

namespace Abacus.Pricing.Models
{
    public class Payment
    {
        public Payment(DateTime paymentDate, CurrencyAmount amount, DateTime? exDate = null)
        {
            PaymentDate = paymentDate;
            ExDate = exDate;
            Amount = amount;
        }

        public DateTime PaymentDate { get; }

        public DateTime? ExDate { get; }

        public CurrencyAmount Amount { get; }
    }
}