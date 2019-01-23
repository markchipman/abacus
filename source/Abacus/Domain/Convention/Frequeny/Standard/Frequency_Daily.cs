namespace Abacus.Domain
{
    internal sealed class Frequency_Daily : Frequency
    {
        public Frequency_Daily()
            : base(TimeDuration.InDays(1))
        {
        }
    }
}
