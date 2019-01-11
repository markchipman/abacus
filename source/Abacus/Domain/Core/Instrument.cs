namespace Abacus.Domain.Core
{
    public abstract class Instrument : IProvideContext<Instrument>
    {
        public abstract void ProvideContext(IAcceptContext<Instrument> context);
    }

    public interface IProvideContext<out TBase>
    {
        void ProvideContext(IAcceptContext<TBase> context);
    }

    public interface IAcceptContext<in TBase>
    {
        void AcceptContext<T>(T target) where T : TBase;
    }
}
