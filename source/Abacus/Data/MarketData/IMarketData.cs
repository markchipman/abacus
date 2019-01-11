namespace Abacus.Data.MarketData
{
    public interface IMarketData
    {
        T GetMarketData<T>(IMarketDataId<T> id);

        T GetMarketDataOrDefault<T>(IMarketDataId<T> id, T @default = default);
    }

    public class MarketData : IMarketData
    {
        public T GetMarketData<T>(IMarketDataId<T> id)
        {
            throw new System.NotImplementedException();
        }

        public T GetMarketDataOrDefault<T>(IMarketDataId<T> id, T @default = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
