namespace Abacus.Core.Resolvable
{
    public class ResolvableByValue<T> : IResolvable<T>
    {
        public ResolvableByValue(T value)
        {
            Value = Value;
        }

        public T Value { get; }

        public T Resolve(IResolver resolver)
        {
            return Value;
        }

        public T ResolveOrDefault(IResolver resolver, T @default = default)
        {
            return Value;
        }
    }
}