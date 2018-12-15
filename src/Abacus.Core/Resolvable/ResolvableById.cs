using Abacus.Core.Identity;

namespace Abacus.Core.Resolvable
{
    public class ResolvableById<T> : IResolvableById<T>
    {
        public ResolvableById(IStandardId id)
        {
            Id = Id;
        }

        public IStandardId Id { get; }

        public T Resolve(IResolver resolver)
        {
            return resolver.Resolve<T, IResolvableById<T>>(this);
        }

        public T ResolveOrDefault(IResolver resolver, T @default = default)
        {
            return resolver.ResolveOrDefault<T, IResolvableById<T>>(this, @default);
        }
    }
}