using System;

namespace Abacus.Pricing.Models
{
    public class CurrencyAmount
    {
        public CurrencyAmount(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public decimal Value { get; }

        public Currency Currency { get; }

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
