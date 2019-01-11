using System;

namespace Abacus.Data.MarketData
{
    public class MarketData : IMarketData
    {
        public T GetMarketData<T>(IMarketDataId<T> id)
        {
            throw new NotImplementedException();
        }

        public T GetMarketDataOrDefault<T>(IMarketDataId<T> id, T @default = default)
        {
            throw new NotImplementedException();
        }
    }
}
