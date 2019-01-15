using System;

namespace Abacus.Domain
{
    public class DailyFrequency : Frequency<DailyFrequency>
    {
        public DailyFrequency() : base("D", TimeDuration.InDays(1)) { }
    }
}
