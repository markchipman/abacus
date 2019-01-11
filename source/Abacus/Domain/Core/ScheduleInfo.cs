using System;

namespace Abacus.Domain
{
    public class ScheduleInfo
    {
        public DateTime UnadjustedStartDate { get; }

        public DateTime UnadjustedEndDate { get; }

        public DateTime StartDate { get; }

        public DayCountConvention DayCountConvention { get; }

        public RollConvention RollConvention { get; }

        public DateTime EndDate { get; }

        public Frequency Frequency { get; }
    }
}
