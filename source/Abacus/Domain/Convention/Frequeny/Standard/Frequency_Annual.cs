namespace Abacus.Domain
{
    internal sealed class Frequency_Annual : TimeDurationFrequency
    {
        public Frequency_Annual()
            : base(TimeDuration.InYears(1))
        {
        }
    }
}
