using System;

namespace Abacus.Domain
{
    public class MonthlyFrequency : Frequency<MonthlyFrequency>
    {
        public MonthlyFrequency() : base("M", TimeDuration.InDays(1)) { }
    }
}
