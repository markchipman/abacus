namespace Abacus.Domain
{
    public sealed class Frequency_Annual : Frequency<Frequency_Annual>
    {
        public Frequency_Annual()
            : base("A", TimeDuration.InYears(1))
        {
        }
    }
}
