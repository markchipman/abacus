using System;

namespace Abacus.Pricing.Models
{
    public class Payment
    {
        public Payment(DateTime paymentDate, CurrencyAmount amount, DateTime? detachmentDate = null)
        {
            PaymentDate = paymentDate;
            ExDate = detachmentDate;
            Amount = amount;
        }

        public DateTime PaymentDate { get; }

        public DateTime? ExDate { get; }

        public CurrencyAmount Amount { get; }
    }
}