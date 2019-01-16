using System;
using System.Collections.Generic;

namespace Abacus.Enums
{
    public abstract class Enumeration<TId> : IEquatable<Enumeration<TId>>
    {
        protected Enumeration(TId id)
        {
            if (id == default)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
        }

        public TId Id { get; }

        public bool Equals(Enumeration<TId> other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public sealed override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Enumeration<TId>)obj);
        }

        public sealed override int GetHashCode()
        {
            return EqualityComparer<TId>.Default.GetHashCode(Id);
        }

        public sealed override string ToString()
        {
            return Id?.ToString() ?? "NULL-ID";
        }
    }
}
