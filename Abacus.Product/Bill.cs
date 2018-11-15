namespace Abacus.Product
{
    public interface IResolveable<T> where T : class
    {
        T Resolve(IResolver resolver);

        T ResolveOrDefault(IResolver resolver, T @default = default);
    }

    public interface IResolver
    {
        T Resolve<T>(IResolveableById<T> res) where T : class;

        T ResolveOrDefault<T>(IResolveableById<T> res, T defaultValue = default) where T : class;

        T Resolve<T>(IResolveableByValue<T> res) where T : class;

        T ResolveOrDefault<T>(IResolveableByValue<T> res, T defaultValue = default) where T : class;
    }

    public interface IStandardId
    {
        string Scheme { get; }

        string Value { get; }
    }

    public interface IResolveableById<T> : IResolveable<T> where T : class
    {
        IStandardId Id { get; }
    }

    public class ResolveableById<T> : IResolveableById<T> where T : class
    {
        public ResolveableById(IStandardId id)
        {
            Id = Id;
        }

        public IStandardId Id { get; }

        public T Resolve(IResolver resolver)
        {
            return resolver.Resolve(this);
        }

        public T ResolveOrDefault(IResolver resolver, T @default = null)
        {
            return resolver.ResolveOrDefault(this, @default);
        }
    }

    public interface IResolveableByValue<T> : IResolveable<T> where T : class
    {
        T Value { get; }
    }

    public class ResolveableByValue<T> : IResolveableByValue<T> where T : class
    {
        public ResolveableByValue(T value)
        {
            Value = Value;
        }

        public T Value { get; }

        public T Resolve(IResolver resolver)
        {
            return resolver.Resolve(this);
        }

        public T ResolveOrDefault(IResolver resolver, T @default = null)
        {
            return resolver.ResolveOrDefault(this, @default);
        }
    }

    public interface ISecurity
    {
    }

    public class Bill
    {
        public IResolveable<ISecurity> Security { get; set; }
    }

    public static class Test
    {
        public static void Main()
        {
            var x = new Bill();
            x.Security = new ResolveableByValue<ISecurity>(null);
            x.Security = new ResolveableById<ISecurity>(null);
            var security = x.Security.Resolve(null);
        }
    }
}
