namespace Abacus.Core.Resolvable
{
    public class ResolvableByValue<T> : IResolvableByValue<T>
    {
        public ResolvableByValue(T value)
        {
            Value = Value;
        }

        public T Value { get; }

        public T Resolve(IResolver resolver)
        {
            return resolver.Resolve<T, IResolvableByValue<T>>(this);
        }

        public T ResolveOrDefault(IResolver resolver, T @default = default)
        {
            return resolver.ResolveOrDefault<T, IResolvableByValue<T>>(this, @default);
        }
    }
}