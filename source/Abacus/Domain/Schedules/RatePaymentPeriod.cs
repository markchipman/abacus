using System;

namespace Abacus.Domain
{
    public class RatePaymentPeriod : PaymentPeriod
    {
        public RatePaymentPeriod(DateTime startDate, DateTime endDate, DateTime adjustedStart, DateTime adjustedEndDate, DateTime paymentDate, DateTime adjustedPaymentDate, CurrencyAmount notional, Rate rate)
            : base(startDate, endDate, adjustedStart, adjustedEndDate, paymentDate, adjustedPaymentDate, notional)
        {
            Rate = rate;
        }

        public Rate Rate { get; }

        public override Payment AsPayment()
        {
            return new Payment(PaymentDate, AdjustedPaymentDate, Notional * Rate.Amount, ExDate);
        }

        public override string ToString()
        {
            return base.ToString() + " @ " + Rate;
        }
    }
}
