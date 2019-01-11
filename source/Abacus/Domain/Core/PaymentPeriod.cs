using System;

namespace Abacus.Domain.Core
{
    public class PaymentPeriod : Period
    {
        public DateTime PaymentDate { get; }

        public DateTime? ExDate { get; }

        public CurrencyAmount Notional { get; }

        public virtual Payment GetPayment()
        {
            return new Payment(PaymentDate, Notional, ExDate);
        }
    }
}
