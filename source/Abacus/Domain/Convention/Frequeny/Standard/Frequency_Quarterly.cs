namespace Abacus.Domain
{
    internal sealed class Frequency_Quarterly : TimeDurationFrequency
    {
        public Frequency_Quarterly()
            : base(TimeDuration.InMonths(3))
        {
        }
    }
}
