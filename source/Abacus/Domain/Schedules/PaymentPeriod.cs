using System;
using Abacus.Debugging;

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

        public virtual Payment AsPayment()
        {
            return new Payment(PaymentDate, AdjustedPaymentDate, Notional, ExDate);
        }

        public override string ToString()
        {
            return base.ToString() + ": " + Notional + " on " + PaymentDate.DebugToString() + " Ex:" + ExDate.DebugToString("NONE");
        }
    }
}
