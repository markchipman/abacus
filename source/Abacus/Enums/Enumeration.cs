using System;

namespace Abacus.Enums
{
    public abstract class Enumeration<TId> : IEquatable<Enumeration<TId>>
    {
        public abstract TId Id { get; }

        public bool Equals(Enumeration<TId> other)
        {
            throw new NotImplementedException();
        }
    }
}
