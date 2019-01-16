namespace Abacus.Domain
{
    public sealed class WeeklyFrequency : Frequency<WeeklyFrequency>
    {
        public WeeklyFrequency()
            : base("W", TimeDuration.InWeeks(1))
        {
        }
    }
}
