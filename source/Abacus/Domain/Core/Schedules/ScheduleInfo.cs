using System;

namespace Abacus.Domain
{
    public class ScheduleInfo
    {
        public ScheduleInfo(DateTime startDate, DateTime endDate, RollConvention rollConvention, DayCountConvention dayCountConvention, Frequency frequency, DateTime? exDate = null)
        {
            if (rollConvention == null)
            {
                throw new ArgumentNullException(nameof(rollConvention));
            }
            if (dayCountConvention == null)
            {
                throw new ArgumentNullException(nameof(dayCountConvention));
            }

            StartDate = startDate;
            EndDate = endDate;
            RollConvention = rollConvention;
            DayCountConvention = dayCountConvention;
            Frequency = frequency;
            ExDate = exDate;
            AdjustedStartDate = rollConvention.Adjust(StartDate);
            AdjustedEndDate = rollConvention.Adjust(EndDate);
        }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public DateTime AdjustedStartDate { get; }

        public DateTime AdjustedEndDate { get; }

        public RollConvention RollConvention { get; }

        public DayCountConvention DayCountConvention { get; }

        public Frequency Frequency { get; }

        public DateTime? ExDate { get; }
    }
}
