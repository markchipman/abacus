namespace Abacus.Core.Resolvable
{
    public class ResolvableByValue<T> : Resolvable<T>
    {
        private readonly T value;

        public ResolvableByValue(T value)
        {
            this.value = value;
        }

        protected override T Resolve(IResolver resolver)
        {
            return value;
        }
    }
}