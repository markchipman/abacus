namespace Abacus.Domain
{
    public sealed class MonthlyFrequency : Frequency<MonthlyFrequency>
    {
        public MonthlyFrequency()
            : base("M", TimeDuration.InMonths(1))
        {
        }
    }
}
