namespace Abacus.Core.Resolvable
{
    public interface IResolvable<T>
    {
        T Resolve(IResolver resolver);

        T ResolveOrDefault(IResolver resolver, T @default = default);
    }
}