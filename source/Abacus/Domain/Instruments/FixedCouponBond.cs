using Abacus.Context;

namespace Abacus.Domain
{
    public sealed class FixedCouponBond : InstrumentWithSchedule<RatePaymentPeriod>
    {
        public FixedCouponBond(Counterparty issuer, CurrencyAmount notional, Rate fixedRate, ScheduleInfo scheduleInfo)
            : base(scheduleInfo)
        {
            if (issuer == null)
            {
                throw new System.ArgumentNullException(nameof(issuer));
            }
            if (notional == null)
            {
                throw new System.ArgumentNullException(nameof(notional));
            }
            if (fixedRate == null)
            {
                throw new System.ArgumentNullException(nameof(fixedRate));
            }
            Issuer = issuer;
            Notional = notional;
            FixedRate = fixedRate;
        }

        public Counterparty Issuer { get; }

        public CurrencyAmount Notional { get; }

        public Rate FixedRate { get; }

        public override void ProvideContext(IAcceptContext<Instrument> target)
        {
            target?.AcceptContext(this);
        }
    }
}
