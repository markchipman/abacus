using Abacus.Core.Identity;

namespace Abacus.Core.Resolvable
{
    public interface IResolvableById<T> : IResolvable<T>
    {
        IStandardId Id { get; }
    }
}