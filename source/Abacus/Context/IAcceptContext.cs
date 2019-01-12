namespace Abacus.Context
{
    public interface IAcceptContext<in TBase>
    {
        void AcceptContext<T>(T target) where T : TBase;
    }
}
