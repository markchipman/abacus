namespace Abacus.Core.Resolvable
{
    public interface IResolver
    {
        T Resolve<T, R>(R resolvable) where R : IResolvable<T>;

        T ResolveOrDefault<T, R>(R resolvable, T @default = default) where R : IResolvable<T>;
    }
}