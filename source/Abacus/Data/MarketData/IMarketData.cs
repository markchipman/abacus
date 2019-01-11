namespace Abacus.Data.MarketData
{
    public interface IMarketData
    {
        T GetMarketData<T>(IMarketDataId<T> id);

        T GetMarketDataOrDefault<T>(IMarketDataId<T> id, T @default = default);
    }
}
