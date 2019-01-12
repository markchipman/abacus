namespace Abacus.Domain.Core
{
    public class Rate
    {
        public Rate(decimal amount, Frequency frequency)
        {
            Amount = amount;
            Frequency = frequency;
        }

        public decimal Amount { get; }

        public Frequency Frequency { get; }
    }
}
