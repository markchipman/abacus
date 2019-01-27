namespace Abacus.Domain
{
    internal sealed class Frequency_Annually : TimeDurationFrequency
    {
        public Frequency_Annually()
            : base(TimeDuration.InYears(1))
        {
        }
    }
}
