using Abacus.Context;

namespace Abacus.Domain.Core
{
    public abstract class Instrument : IProvideContext<Instrument>
    {
        public abstract void ProvideContext(IAcceptContext<Instrument> context);
    }
}
