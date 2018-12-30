using Abacus.Core.Resolvable;

public abstract class Resolvable<T> : IResolvable<T>
{
    protected abstract T Resolve(IResolver resolver);

    T IResolvable<T>.Resolve(IResolver resolver)
    {
        return Resolve(resolver);
    }
}