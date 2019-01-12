using Abacus.Context;
using Abacus.Domain.Core;

namespace Abacus.Engine
{
    public class InstrumentCalculationContextProvider : IAcceptContext<Instrument>
    {
        public void AcceptContext<TTarget>(TTarget context) where TTarget : Instrument
        {
            Context = new InstrumentCalculationContext<TTarget>(context);
        }

        public InstrumentCalculationContext Context { get; private set; }
    }
}
