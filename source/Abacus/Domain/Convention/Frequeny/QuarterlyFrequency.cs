namespace Abacus.Domain
{
    public sealed class QuarterlyFrequency : Frequency<QuarterlyFrequency>
    {
        public QuarterlyFrequency()
            : base("Q", TimeDuration.InMonths(3))
        {
        }
    }
}
