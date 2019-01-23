namespace Abacus.Domain
{
    internal sealed class Frequency_Weekly : Frequency
    {
        public Frequency_Weekly()
            : base(TimeDuration.InWeeks(1))
        {
        }
    }
}
