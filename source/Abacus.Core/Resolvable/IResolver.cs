namespace Abacus.Core.Resolvable
{
    public interface IResolver
    {
        T Resolve<T, R>(R resolvable) where R : IResolvable<T>;
    }

    public class Resolver : IResolver
    {
        public T Resolve<T, R>(R resolvable) where R : IResolvable<T>
        {
            throw new System.NotImplementedException();
        }
    }
}
