namespace Abacus.Domain
{
    public class QuarterlyFrequency : Frequency<QuarterlyFrequency>
    {
        public QuarterlyFrequency()
            : base("Q", TimeDuration.InMonths(3))
        {
        }
    }
}
