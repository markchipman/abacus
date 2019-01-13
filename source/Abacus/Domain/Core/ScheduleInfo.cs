using System;

namespace Abacus.Domain
{
    public class ScheduleInfo
    {
        public ScheduleInfo(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;

            // TODO - rest of props
        }

        public DateTime UnadjustedStartDate { get; }

        public DateTime UnadjustedEndDate { get; }

        public DateTime StartDate { get; }

        public DayCountConvention DayCountConvention { get; }

        public RollConvention RollConvention { get; }

        public DateTime EndDate { get; }

        public Frequency Frequency { get; }

        public DateTime? ExDate { get; }

        public Schedule<TPeriod> ExpandToSchedule<TPeriod>()
        {
            return Schedule<TPeriod>.From(this);
        }
    }
}
