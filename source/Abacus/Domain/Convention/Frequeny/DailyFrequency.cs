namespace Abacus.Domain
{
    public sealed class DailyFrequency : Frequency<DailyFrequency>
    {
        public DailyFrequency()
            : base("D", TimeDuration.InDays(1))
        {
        }
    }
}
