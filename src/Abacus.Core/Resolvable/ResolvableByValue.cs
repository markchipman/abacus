namespace Abacus.Core.Resolvable
{
    public class ResolvableByValue<T> : Resolvable<T>
    {
        private readonly T _value;

        public ResolvableByValue(T value)
        {
            _value = value;
        }

        protected override T Resolve(IResolver resolver)
        {
            return _value;
        }
    }
}