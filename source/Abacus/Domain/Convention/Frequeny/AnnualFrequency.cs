namespace Abacus.Domain
{
    public sealed class AnnualFrequency : Frequency<AnnualFrequency>
    {
        public AnnualFrequency()
            : base("A", TimeDuration.InYears(1))
        {
        }
    }
}
