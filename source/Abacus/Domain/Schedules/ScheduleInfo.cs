﻿using System;
using Abacus.Debugging;

namespace Abacus.Domain
{
    public class ScheduleInfo
    {
        public ScheduleInfo(DateTime startDate, DateTime endDate, Frequency frequency, RollConvention rollConvention = null, DateTime? exDate = null)
        {
            if (frequency == null)
            {
                throw new ArgumentNullException(nameof(frequency));
            }
            if (rollConvention == null)
            {
                rollConvention = NoneRollConvention.Instance;
            }

            StartDate = startDate;
            EndDate = endDate;
            Frequency = frequency;
            RollConvention = rollConvention;
            ExDate = exDate;
            AdjustedStartDate = rollConvention.Adjust(StartDate);
            AdjustedEndDate = rollConvention.Adjust(EndDate);
        }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public DateTime AdjustedStartDate { get; }

        public DateTime AdjustedEndDate { get; }

        public Frequency Frequency { get; }

        public RollConvention RollConvention { get; }

        public DateTime? ExDate { get; }

        public override string ToString()
        {
            return AdjustedStartDate.DebugToString() + "->" + AdjustedEndDate.DebugToString() + " Freq:" + Frequency + " RC:" + RollConvention + " Ex:" + ExDate.DebugToString("NONE");
        }
    }
}