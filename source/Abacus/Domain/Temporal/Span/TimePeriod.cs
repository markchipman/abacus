using System;
using Abacus.Debugging;

namespace Abacus.Domain
{
    public class TimePeriod
    {
        public TimePeriod(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; }

        public DateTime End { get; }

        public override string ToString()
        {
            return Start.DebugToStringDateRange(End);
        }
    }
}
