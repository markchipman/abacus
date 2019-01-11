namespace Abacus.Domain
{
    public abstract class Instrument : IProvideContext<Instrument>
    {
        public abstract void ProvideContext(IAcceptContext<Instrument> context);
    }

    public interface IProvideContext<TBase>
    {
        void ProvideContext(IAcceptContext<TBase> context);
    }

    public interface IAcceptContext<TBase>
    {
        void AcceptContext<T>(T target) where T : TBase;
    }
}
