using Abacus.Core.Resolvable;

public abstract class Resolvable<T> : IResolvable<T>
{
    protected abstract T Resolve(IResolver resolver);

    protected abstract T ResolveOrDefault(IResolver resolver, T @default);

    T IResolvable<T>.Resolve(IResolver resolver)
    {
        return Resolve(resolver);
    }

    T IResolvable<T>.ResolveOrDefault(IResolver resolver, T @default)
    {
        return ResolveOrDefault(resolver, @default);
    }
}