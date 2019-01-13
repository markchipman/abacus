using System;

namespace Abacus.Domain
{
    public class PaymentPeriod : Period
    {
        public PaymentPeriod(DateTime startDate, DateTime endDate, DateTime adjustedStart, DateTime adjustedEndDate, DateTime paymentDate, DateTime adjustedPaymentDate, CurrencyAmount notional)
            : base(startDate, endDate, adjustedStart, adjustedEndDate)
        {
            PaymentDate = paymentDate;
            AdjustedPaymentDate = adjustedPaymentDate;
            Notional = notional;
        }

        public DateTime PaymentDate { get; }

        public DateTime AdjustedPaymentDate { get; }

        public DateTime? ExDate { get; }

        public CurrencyAmount Notional { get; }

        public virtual Payment Payment => new Payment(PaymentDate, AdjustedPaymentDate, Notional, ExDate);
    }
}
