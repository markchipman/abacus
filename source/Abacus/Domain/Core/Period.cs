using System;

namespace Abacus.Domain
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            // TODO - rest of props
        }

        public DateTime UnadjustedStartDate { get; }

        public DateTime UnadjustedEndDate { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }
    }
}
