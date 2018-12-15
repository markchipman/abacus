namespace Abacus.Core.Resolvable
{
    public interface IResolvableByValue<T> : IResolvable<T>
    {
        T Value { get; }
    }
}