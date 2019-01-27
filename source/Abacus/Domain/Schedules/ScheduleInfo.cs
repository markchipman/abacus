using System;
using Abacus.Debugging;

namespace Abacus.Domain
{
    public class ScheduleInfo
    {
        public ScheduleInfo(DateTime startDate, DateTime endDate, Frequency frequency, DayRollConvention rollConvention = null, DateTime? exDate = null)
        {
            if (frequency == null)
            {
                throw new ArgumentNullException(nameof(frequency));
            }
            if (rollConvention == null)
            {
                rollConvention = StandardDayRollConvention._None;
            }

            StartDate = startDate;
            EndDate = endDate;
            Frequency = frequency;
            RollConvention = rollConvention;
            ExDate = exDate;
            AdjustedStartDate = rollConvention.Roll(StartDate);
            AdjustedEndDate = rollConvention.Roll(EndDate);
        }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public DateTime AdjustedStartDate { get; }

        public DateTime AdjustedEndDate { get; }

        public Frequency Frequency { get; }

        public DayRollConvention RollConvention { get; }

        public DateTime? ExDate { get; }

        public override string ToString()
        {
            return AdjustedStartDate.DebugToString() + "->" + AdjustedEndDate.DebugToString() + " Freq:" + Frequency + " RC:" + RollConvention + " Ex:" + ExDate.DebugToString("NONE");
        }
    }
}
