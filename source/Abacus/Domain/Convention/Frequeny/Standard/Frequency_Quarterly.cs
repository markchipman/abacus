namespace Abacus.Domain
{
    internal sealed class Frequency_Quarterly : Frequency
    {
        public Frequency_Quarterly()
            : base(TimeDuration.InMonths(3))
        {
        }
    }
}
