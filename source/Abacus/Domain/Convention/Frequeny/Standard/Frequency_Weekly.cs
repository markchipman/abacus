namespace Abacus.Domain
{
    internal sealed class Frequency_Weekly : TimeDurationFrequency
    {
        public Frequency_Weekly()
            : base(TimeDuration.InWeeks(1))
        {
        }
    }
}
