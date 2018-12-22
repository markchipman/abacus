namespace Abacus.Core.Resolvable
{
    public interface IResolvable<T>
    {
        T Resolve(IResolver resolver);
    }
}