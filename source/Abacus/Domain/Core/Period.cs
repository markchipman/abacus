using System;

namespace Abacus.Domain
{
    public class Period
    {
        public DateTime UnadjustedStartDate { get; }

        public DateTime UnadjustedEndDate { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }
    }
}
