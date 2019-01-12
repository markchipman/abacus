namespace Abacus.Data.MarketData
{
    public class MarketData : IMarketData
    {
        public T GetMarketData<T>(IMarketDataId<T> id)
        {
            return default;
        }

        public T GetMarketDataOrDefault<T>(IMarketDataId<T> id, T @default = default)
        {
            return @default;
        }
    }
}
