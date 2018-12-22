using Abacus.Core.Identity;

namespace Abacus.Core.Resolvable
{
    public class ResolvableById<T> : IResolvable<T>
    {
        public ResolvableById(StandardId id)
        {
            Id = Id;
        }

        public StandardId Id { get; }

        public T Resolve(IResolver resolver)
        {
            return resolver.Resolve<T, ResolvableById<T>>(this);
        }

        public T ResolveOrDefault(IResolver resolver, T @default = default)
        {
            return resolver.ResolveOrDefault<T, ResolvableById<T>>(this, @default);
        }
    }
}