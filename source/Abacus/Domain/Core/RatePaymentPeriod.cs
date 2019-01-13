using System;

namespace Abacus.Domain
{
    public class RatePaymentPeriod : PaymentPeriod
    {
        public RatePaymentPeriod(DateTime startDate, DateTime endDate, DateTime paymentDate, CurrencyAmount notional, Rate rate)
            : base(startDate, endDate, paymentDate, notional)
        {
            Rate = rate;
        }

        public Rate Rate { get; }

        public override Payment GetPayment()
        {
            return new Payment(PaymentDate, Notional * Rate.Amount, ExDate);
        }
    }
}
