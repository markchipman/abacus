namespace Abacus.Domain
{
    internal sealed class Frequency_Annual : Frequency<Frequency_Annual>
    {
        public Frequency_Annual()
            : base("A", TimeDuration.InYears(1))
        {
        }
    }
}
