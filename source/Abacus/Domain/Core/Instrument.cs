using Abacus.Context;

namespace Abacus.Domain
{

    public abstract class Instrument : IProvideContext<Instrument>
    {
        public abstract void ProvideContext(IAcceptContext<Instrument> target);
    }
}
