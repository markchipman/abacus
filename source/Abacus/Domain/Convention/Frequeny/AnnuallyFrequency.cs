namespace Abacus.Domain
{
    public class AnnuallyFrequency : Frequency<AnnuallyFrequency>
    {
        public AnnuallyFrequency()
            : base("A", TimeDuration.InYears(1))
        {
        }
    }
}
