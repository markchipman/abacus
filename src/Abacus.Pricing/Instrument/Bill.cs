namespace Abacus.Pricing.Instrument
{
    public class Bill : IBill
    {
        public Bill(ISecurity security)
        {
            Security = security;
        }

        public ISecurity Security { get; }
    }
}
