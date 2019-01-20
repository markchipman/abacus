namespace Abacus.Domain
{
    internal sealed class Frequency_Quarterly : Frequency<Frequency_Quarterly>
    {
        public Frequency_Quarterly()
            : base("Q", TimeDuration.InMonths(3))
        {
        }
    }
}
