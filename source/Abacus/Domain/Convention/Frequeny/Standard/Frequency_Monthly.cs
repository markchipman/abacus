namespace Abacus.Domain
{
    internal sealed class Frequency_Monthly : Frequency
    {
        public Frequency_Monthly()
            : base(TimeDuration.InMonths(1))
        {
        }
    }
}
