using System;

namespace Abacus.Domain
{
    public class WeeklyFrequency : Frequency<WeeklyFrequency>
    {
        public WeeklyFrequency() : base("W", TimeDuration.InWeeks(1)) { }
    }
}
