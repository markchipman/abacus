namespace Abacus.Domain
{
    internal sealed class Frequency_SemiAnnual : Frequency
    {
        public Frequency_SemiAnnual()
            : base(TimeDuration.InMonths(6))
        {
        }
    }
}
