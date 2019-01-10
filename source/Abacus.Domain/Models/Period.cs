using System;

namespace Abacus.Domain.Models
{
    public class Period
    {
        public DateTime UnAdjustedStartDate { get; }

        public DateTime UnAdjustedEndDate { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }
    }
}
