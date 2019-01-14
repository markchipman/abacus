using System;
using System.Collections.Generic;

namespace Abacus.Enums
{
    public abstract class Enumeration<TId, TName> : Enumeration<TId>
    {
        protected Enumeration(TId id, TName name)
            : base(id)
        {
            if (name == default)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public TName Name { get; }

        public override string ToString()
        {
            return base.ToString() + " (" + Name + ")";
        }
    }

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

        public override bool Equals(object obj)
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

        public override int GetHashCode()
        {
            return EqualityComparer<TId>.Default.GetHashCode(Id);
        }

        public override string ToString()
        {
            return Id?.ToString() ?? "NULL-ID";
        }
    }
}
