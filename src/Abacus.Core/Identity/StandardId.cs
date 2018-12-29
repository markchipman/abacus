using System;
using System.Linq;
using Abacus.Common;

namespace Abacus.Core.Identity
{
    public class StandardId : IEquatable<StandardId>, IComparable<StandardId>
    {
        private static readonly string IdSeparator = "~";

        private readonly ImmutableHelper immutableHelper = new ImmutableHelper();

        public StandardId(string scheme, string value)
        {
            // TODO - validate with regex
            Scheme = scheme;
            Value = value;
        }

        public string Scheme { get; }

        public string Value { get; }

        public bool Equals(StandardId other)
        {
            if (other == null) return false;
            if (ReferenceEquals(other, this)) return true;
            return Equals(Scheme, other.Scheme) && Equals(Value, other.Value);
        }

        public int CompareTo(StandardId other)
        {
            return new Func<int>[] {
                () => Scheme.CompareTo(other.Scheme), 
                () => Value.CompareTo(other.Value)
            }.Select(c => c()).FirstOrDefault(x => x != 0);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as StandardId);
        }

        public override int GetHashCode()
        {
            return immutableHelper.GetCachedHashCode(() =>
            {
                unchecked
                {
                    const int hashBase = (int)2166136261;
                    const int hashMult = 16777619;
                    var hash = hashBase;
                    hash = (hash * hashMult) ^ Scheme?.GetHashCode() ?? 0;
                    hash = (hash * hashMult) ^ Value?.GetHashCode() ?? 0;
                    return hash;
                }
            });
        }

        public override string ToString()
        {
            return immutableHelper.GetCachedToString(() => Scheme + IdSeparator + Value);
        }

        public static StandardId Parse(string id)
        {
            // TODO - validate with regex
            int idTokenPos;
            if (string.IsNullOrEmpty(id) || (idTokenPos = id.IndexOf(IdSeparator, StringComparison.Ordinal)) < 0)
            {
                throw new ArgumentException("Invalid id format: " + id);
            }
            return new StandardId(id.Substring(0, idTokenPos), id.Substring(idTokenPos + 1));
        }
    }
}
