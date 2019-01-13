using System;

namespace Abacus.Domain
{
    public class Payment
    {
        public Payment(DateTime paymentDate, DateTime adjustedPaymentDate, CurrencyAmount amount, DateTime? exDate = null)
        {
            PaymentDate = paymentDate;
            AdjustedPaymentDate = adjustedPaymentDate;
            ExDate = exDate;
            Amount = amount;
        }

        public DateTime PaymentDate { get; }

        public DateTime AdjustedPaymentDate { get; }

        public DateTime? ExDate { get; }

        public CurrencyAmount Amount { get; }
    }
}
