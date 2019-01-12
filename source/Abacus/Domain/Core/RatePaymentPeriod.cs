using System;

namespace Abacus.Domain.Core
{
    public class RatePaymentPeriod : PaymentPeriod
    {
        public RatePaymentPeriod(DateTime startDate, DateTime endDate, DateTime paymentDate, CurrencyAmount notional, decimal rate)
            : base(startDate, endDate, paymentDate, notional)
        {
            Rate = rate;
        }

        public decimal Rate { get; }

        public override Payment GetPayment()
        {
            return new Payment(PaymentDate, Notional * Rate, ExDate);
        }
    }
}
