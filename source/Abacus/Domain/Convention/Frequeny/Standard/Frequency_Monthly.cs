namespace Abacus.Domain
{
    internal sealed class Frequency_Monthly : TimeDurationFrequency
    {
        public Frequency_Monthly()
            : base(TimeDuration.InMonths(1))
        {
        }
    }
}
