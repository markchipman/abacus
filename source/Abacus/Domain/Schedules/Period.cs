using System;
using Abacus.Debugging;

namespace Abacus.Domain
{
    public abstract class Period
    {
        protected Period(DateTime startDate, DateTime endDate, DateTime adjustedStartDate, DateTime adjustedEndDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            AdjustedStartDate = adjustedStartDate;
            AdjustedEndDate = adjustedEndDate;
        }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public DateTime AdjustedStartDate { get; }

        public DateTime AdjustedEndDate { get; }

        public override string ToString()
        {
            return AdjustedStartDate.DebugToString() + "->" + AdjustedEndDate.DebugToString();
        }
    }
}
