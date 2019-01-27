namespace Abacus.Domain
{
    internal sealed class Frequency_SemiAnnually : TimeDurationFrequency
    {
        public Frequency_SemiAnnually()
            : base(TimeDuration.InMonths(6))
        {
        }
    }
}
