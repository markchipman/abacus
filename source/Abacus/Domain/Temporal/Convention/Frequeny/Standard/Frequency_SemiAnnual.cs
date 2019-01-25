namespace Abacus.Domain
{
    internal sealed class Frequency_SemiAnnual : TimeDurationFrequency
    {
        public Frequency_SemiAnnual()
            : base(TimeDuration.InMonths(6))
        {
        }
    }
}
