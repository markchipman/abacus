namespace Abacus.Context
{
    public interface IProvideContext<out TBase>
    {
        void ProvideContext(IAcceptContext<TBase> context);
    }
}
