using Abacus.Context;
using Abacus.Debugging;

namespace Abacus.Domain
{
    public sealed class FixedCouponBond : InstrumentWithSchedule<RatePaymentPeriod>
    {
        public FixedCouponBond(Counterparty issuer, CurrencyAmount notional, Rate fixedRate, ScheduleInfo scheduleInfo)
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
            if (scheduleInfo == null)
            {
                throw new System.ArgumentNullException(nameof(scheduleInfo));
            }

            Issuer = issuer;
            Notional = notional;
            FixedRate = fixedRate;
            ScheduleInfo = scheduleInfo;
            NominalPayment = new Payment(ScheduleInfo.EndDate, ScheduleInfo.EndDate, Notional); // TODO payment dates
            Schedule = RatePaymentSchedule.GenerateFixedRateSchedule(ScheduleInfo, Notional, FixedRate);
        }

        public Counterparty Issuer { get; }

        public CurrencyAmount Notional { get; }

        public Rate FixedRate { get; }

        public ScheduleInfo ScheduleInfo { get; }

        public Payment NominalPayment { get; }

        public override Schedule<RatePaymentPeriod> Schedule { get; }

        public override void ProvideContext(IAcceptContext<Instrument> target)
        {
            target?.AcceptContext(this);
        }

        public override string ToString()
        {
            return ScheduleInfo.StartDate.DebugToStringDateRange(ScheduleInfo.EndDate) + " " + Notional + " @ " + FixedRate + "/" + ScheduleInfo.Frequency + " " + nameof(FixedCouponBond) + " issued by " + Issuer;
        }
    }
}
