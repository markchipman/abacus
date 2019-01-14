using Abacus.Context;

namespace Abacus.Engine
{
    public interface IContextWrapper<TInputContextBase, TOutputContext> : IAcceptContext<TInputContextBase>
    {
        TOutputContext OutputContext { get; }
    }
}
