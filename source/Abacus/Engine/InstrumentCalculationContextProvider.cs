using Abacus.Domain.Core;

namespace Abacus.Engine
{
    public class InstrumentCalculationContextProvider : IInstrumentCalculationContextProvider
    {
        public void AcceptContext<TTarget>(TTarget context) where TTarget : Instrument
        {
            Context = new InstrumentCalculationContext<TTarget>(context);
        }

        public ICalculationContext Context { get; private set; }
    }
}
