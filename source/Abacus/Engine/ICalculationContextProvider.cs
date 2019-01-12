using Abacus.Context;

namespace Abacus.Engine
{
    public interface ICalculationContextProvider<TTarget> : IAcceptContext<TTarget>
    {
        ICalculationContext Context { get; }
    }
}
