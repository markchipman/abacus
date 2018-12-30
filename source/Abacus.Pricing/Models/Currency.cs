namespace Abacus.Pricing.Models
{
    public class Currency
    {
        public CurrencyAmount ZeroAmount()
        {
            return new CurrencyAmount(0, this);
        }
    }
}