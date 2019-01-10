namespace Abacus.Data.MarketData
{
    public interface IMarketData
    {
        T GetMarketData<T>();

        T GetMarketDataOrDefault<T>(T @default = default);
    }
}
