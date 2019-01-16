namespace Abacus.Domain
{
    public sealed class SemiAnnualFrequency : Frequency<SemiAnnualFrequency>
    {
        public SemiAnnualFrequency()
            : base("S", TimeDuration.InMonths(6))
        {
        }
    }
}
