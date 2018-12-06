using System;

namespace Abakus.Product
{
    public interface IResolvable<T>
    {
        T Resolve(IResolver resolver);

        T ResolveOrDefault(IResolver resolver, T @default = default);
    }

    public interface IResolver
    {
        T Resolve<T, R>(R resolvable) where R : IResolvable<T>;

        T ResolveOrDefault<T, R>(R resolvable, T @default = default) where R : IResolvable<T>;
    }

    public interface IStandardId
    {
        string Scheme { get; }

        string Value { get; }
    }

    public interface IResolvableById<T> : IResolvable<T>
    {
        IStandardId Id { get; }
    }

    public class ResolvableById<T> : IResolvableById<T>
    {
        public ResolvableById(IStandardId id)
        {
            Id = Id;
        }

        public IStandardId Id { get; }

        public T Resolve(IResolver resolver)
        {
            return resolver.Resolve<T, IResolvableById<T>>(this);
        }

        public T ResolveOrDefault(IResolver resolver, T @default = default)
        {
            return resolver.ResolveOrDefault<T, IResolvableById<T>>(this, @default);
        }
    }

    public interface IResolvableByValue<T> : IResolvable<T>
    {
        T Value { get; }
    }

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

    public interface ISecurity
    {
    }

    public class ResolvableBill : IResolvable<IBill>
    {
        public IResolvable<ISecurity> Security { get; set; }

        public IBill Resolve(IResolver resolver)
        {
            // helper sugar method - less text than 'resolver.resolve(Security)'
            T resolve<T>(IResolvable<T> resolvable) where T : class => resolver.Resolve<T, IResolvable<T>>(resolvable);

            return new Bill(resolve(Security));
        }

        public IBill ResolveOrDefault(IResolver resolver, IBill @default = null)
        {
            return Resolve(resolver);
        }
    }

    public interface IBill
    {
        ISecurity Security { get; }
    }

    public class Bill : IBill
    {
        public Bill(ISecurity security)
        {
            Security = security;
        }

        public ISecurity Security { get; }
    }

    public static class Test
    {
        public static void Main()
        {
            var rBill = new ResolvableBill
            {
                Security = new ResolvableByValue<ISecurity>(null)
            };

            var bill = rBill.Resolve(null);
        }
    }
}
