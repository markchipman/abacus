﻿namespace Abacus.Domain
{
    public sealed class Frequency_Daily : Frequency<Frequency_Daily>
    {
        public Frequency_Daily()
            : base("D", TimeDuration.InDays(1))
        {
        }
    }
}