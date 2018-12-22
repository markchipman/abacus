namespace Abacus.Core.Resolvable
{
    public class ResolvableByValue<T> : Resolvable<T>
    {
        public ResolvableByValue(T value)
        {
            Value = Value;
        }

        public T Value { get; }

        protected override T Resolve(IResolver resolver)
        {
            return Value;
        }

        protected override T ResolveOrDefault(IResolver resolver, T @default = default)
        {
            return Value;
        }
    }
}