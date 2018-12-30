using System;
using System.Collections.Generic;

namespace Abacus.Pricing.Models
{
    public sealed class FixedCouponBond
    {
        public SecurityId SecurityId { get; }

        public Counterparty Issuer { get; }

        public decimal Notional { get; }

        public Currency Currency { get; }

        public decimal FixedRate { get; }

        public Frequency Frequency { get; }

        public YieldConvention YieldConvention { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public RollConvention RollConvention { get; }

        public DateTime AdjustedStartDate { get; }

        public DateTime AdjustedEndDate { get; }

        public DayCountConvention DayCountConvention { get; }

        public Payment NominalPayment { get; }

        public IReadOnlyList<FixedRatePeriod> CouponSchedule { get; }
    }
}