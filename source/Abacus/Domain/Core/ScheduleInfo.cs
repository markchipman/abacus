using System;

namespace Abacus.Domain
{
    public class ScheduleInfo
    {
        public ScheduleInfo(DateTime startDate, DateTime endDate, Frequency frequency)
        {
            StartDate = startDate;
            EndDate = endDate;
            Frequency = frequency;

            // TODO - rest of props
            DayCountConvention = new DayCountConvention();
            RollConvention = new RollConvention();
        }

        public DateTime UnadjustedStartDate { get; }

        public DateTime UnadjustedEndDate { get; }

        public RollConvention RollConvention { get; }

        public DayCountConvention DayCountConvention { get; }

        public Frequency Frequency { get; }

        public DateTime? ExDate { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }
    }
}
