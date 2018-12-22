namespace Abacus.Core.Resolvable
{
    public interface IResolver
    {
        T Resolve<T, R>(R resolvable) where R : IResolvable<T>;
    }
}