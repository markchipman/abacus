using System;

namespace Abacus.Domain
{
    public class ScheduleInfo
    {
        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public RollConvention RollConvention { get; }

        public DayCountConvention DayCountConvention { get; }

        public Frequency Frequency { get; }

        public DateTime AdjustedStartDate { get; }

        public DateTime AdjustedEndDate { get; }
    }
}
