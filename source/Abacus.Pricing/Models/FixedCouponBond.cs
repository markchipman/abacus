using System.Collections.Generic;

namespace Abacus.Pricing.Models
{
    public sealed class FixedCouponBond
    {
        public Counterparty Issuer { get; }

        public CurrencyAmount Notional { get; }

        public Rate FixedRate { get; }

        public Payment NominalPayment { get; }

        public ScheduleInfo ScheduleInfo { get; }

        public IReadOnlyList<RatePaymentPeriod> CouponSchedule { get; }
    }
}
