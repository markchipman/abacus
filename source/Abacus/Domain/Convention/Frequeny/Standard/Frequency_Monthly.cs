namespace Abacus.Domain
{
    internal sealed class Frequency_Monthly : Frequency<Frequency_Monthly>
    {
        public Frequency_Monthly()
            : base("M", TimeDuration.InMonths(1))
        {
        }
    }
}
