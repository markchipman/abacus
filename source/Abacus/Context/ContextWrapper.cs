namespace Abacus.Engine
{
    public abstract class ContextWrapper<TInputContext, TOutputContext> : IContextWrapper<TInputContext, TOutputContext>
    {
        public TOutputContext OutputContext { get; private set; }

        public void AcceptContext<TContext>(TContext context) where TContext : TInputContext
        {
            OutputContext = WrapContext(context);
        }

        protected abstract TOutputContext WrapContext<TContext>(TContext inputContext) where TContext : TInputContext;
    }
}
