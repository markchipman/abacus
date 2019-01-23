namespace Abacus.Domain
{
    internal sealed class Frequency_Daily : TimeDurationFrequency
    {
        public Frequency_Daily()
            : base(TimeDuration.InDays(1))
        {
        }
    }
}
