using System.Collections.Generic;
using Abacus.Context;
using Abacus.Domain.Core;

namespace Abacus.Domain.Instruments
{
    public sealed class FixedCouponBond : Instrument
    {
        public Counterparty Issuer { get; }

        public CurrencyAmount Notional { get; }

        public Rate FixedRate { get; }

        public Payment NominalPayment { get; }

        public ScheduleInfo ScheduleInfo { get; }

        public IReadOnlyList<RatePaymentPeriod> CouponSchedule { get; }

        public override void ProvideContext(IAcceptContext<Instrument> context)
        {
            context?.AcceptContext(this);
        }
    }
}
