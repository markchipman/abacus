namespace Abacus.Domain
{
    public sealed class Frequency_Weekly : Frequency<Frequency_Weekly>
    {
        public Frequency_Weekly()
            : base("W", TimeDuration.InWeeks(1))
        {
        }
    }
}
