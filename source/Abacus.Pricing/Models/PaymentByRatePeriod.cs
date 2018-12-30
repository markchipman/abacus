namespace Abacus.Pricing.Models
{

    public class RatePaymentPeriod : PaymentPeriod
    {
        public decimal Rate { get; }

        public override Payment GetPayment()
        {
            return new Payment(PaymentDate, Notional * Rate, ExDate);
        }
    }
}