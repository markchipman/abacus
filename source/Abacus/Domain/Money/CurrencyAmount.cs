using System;

namespace Abacus.Domain
{
    public class CurrencyAmount : IEquatable<CurrencyAmount>
    {
        public CurrencyAmount(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public decimal Value { get; }

        public Currency Currency { get; }

        public bool Equals(CurrencyAmount other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Value == other.Value && Equals(Currency, other.Currency);
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

            return Equals((CurrencyAmount)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ (Currency != null ? Currency.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return Value + " " + Currency;
        }

        public static CurrencyAmount operator +(CurrencyAmount first, CurrencyAmount second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException("Cannot add two ammounts of different currencies. First: '" + first + "', Second: '" + second + "'.");
            }

            return new CurrencyAmount(first.Value + second.Value, first.Currency);
        }

        public static CurrencyAmount operator -(CurrencyAmount first, CurrencyAmount second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException("Cannot add two ammounts of different currencies. First: '" + first + "', Second: '" + second + "'.");
            }

            return new CurrencyAmount(first.Value - second.Value, first.Currency);
        }

        public static CurrencyAmount operator *(CurrencyAmount first, CurrencyAmount second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException("Cannot add two ammounts of different currencies. First: '" + first + "', Second: '" + second + "'.");
            }

            return new CurrencyAmount(first.Value * second.Value, first.Currency);
        }

        public static CurrencyAmount operator /(CurrencyAmount first, CurrencyAmount second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException("Cannot add two ammounts of different currencies. First: '" + first + "', Second: '" + second + "'.");
            }

            return new CurrencyAmount(first.Value / second.Value, first.Currency);
        }

        public static CurrencyAmount operator +(CurrencyAmount first, decimal amount)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            return new CurrencyAmount(first.Value + amount, first.Currency);
        }

        public static CurrencyAmount operator -(CurrencyAmount first, decimal amount)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            return new CurrencyAmount(first.Value - amount, first.Currency);
        }

        public static CurrencyAmount operator *(CurrencyAmount first, decimal amount)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            return new CurrencyAmount(first.Value * amount, first.Currency);
        }

        public static CurrencyAmount operator /(CurrencyAmount first, decimal amount)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            return new CurrencyAmount(first.Value / amount, first.Currency);
        }
    }
}
