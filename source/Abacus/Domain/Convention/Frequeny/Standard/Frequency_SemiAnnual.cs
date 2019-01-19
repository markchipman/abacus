﻿namespace Abacus.Domain
{
    public sealed class Frequency_SemiAnnual : Frequency<Frequency_SemiAnnual>
    {
        public Frequency_SemiAnnual()
            : base("S", TimeDuration.InMonths(6))
        {
        }
    }
}