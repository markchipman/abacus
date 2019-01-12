using System.Collections.Generic;
using Abacus.Context;

namespace Abacus.Domain
{
    public sealed class FixedCouponBond : Instrument
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
            NominalPayment = new Payment(scheduleInfo.EndDate, Notional, scheduleInfo.ExDate);
            CouponSchedule = new List<RatePaymentPeriod>
            {
                new RatePaymentPeriod(scheduleInfo.StartDate, scheduleInfo.EndDate, scheduleInfo.EndDate, Notional, FixedRate.Amount)
            };
        }

        public Counterparty Issuer { get; }

        public CurrencyAmount Notional { get; }

        public Rate FixedRate { get; }

        public ScheduleInfo ScheduleInfo { get; }

        public Payment NominalPayment { get; }

        public IReadOnlyList<RatePaymentPeriod> CouponSchedule { get; }

        public override void ProvideContext(IAcceptContext<Instrument> target)
        {
            target?.AcceptContext(this);
        }
    }
}
