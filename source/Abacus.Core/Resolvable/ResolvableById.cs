using Abacus.Core.Identity;

namespace Abacus.Core.Resolvable
{
    public class ResolvableById<T> : Resolvable<T>
    {
        public ResolvableById(StandardId id)
        {
            Id = Id;
        }

        public StandardId Id { get; }

        protected override T Resolve(IResolver resolver)
        {
            return resolver.Resolve<T, ResolvableById<T>>(this);
        }
    }
}
