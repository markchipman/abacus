using Abacus.Domain;

namespace Abacus.Engine
{
    public static class CalculationContextExtensions
    {
        public static CalculationContext ToCalculationContext<TInstrument>(this TInstrument instrument) where TInstrument : Instrument
        {
            var contextWrapper = new InstrumentCalculationContextWrapper();
            instrument.ProvideContext(contextWrapper);
            return contextWrapper.OutputContext;
        }
    }

    public class InstrumentCalculationContextWrapper : ContextWrapper<Instrument, CalculationContext>
    {
        protected override CalculationContext WrapContext<TContext>(TContext inputContext)
        {
            return new InstrumentCalculationContext<TContext>(inputContext);
        }
    }
}
