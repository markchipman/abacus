using System;

namespace Abacus.Pricing.Models
{
    public class ScheduleInfo
    {
        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public RollConvention RollConvention { get; }

        public DayCountConvention DayCountConvention { get; }

        public DateTime AdjustedStartDate { get; }

        public DateTime AdjustedEndDate { get; }
    }
}
