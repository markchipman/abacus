using System;

namespace Abacus.Domain
{
    public class SemiAnnuallyFrequency : Frequency<SemiAnnuallyFrequency>
    {
        public SemiAnnuallyFrequency() : base("S", TimeDuration.InMonths(6)) { }
    }
}
