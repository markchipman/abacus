namespace Abacus.Domain
{
    internal sealed class Frequency_Annual : Frequency
    {
        public Frequency_Annual()
            : base(TimeDuration.InYears(1))
        {
        }
    }
}
