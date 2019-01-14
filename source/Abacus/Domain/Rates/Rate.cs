using System;

namespace Abacus.Domain
{
    public class Rate : IEquatable<Rate>
    {
        public Rate(decimal amount, Frequency frequency)
        {
            Amount = amount;
            Frequency = frequency;
        }

        public decimal Amount { get; }

        public Frequency Frequency { get; }

        public bool Equals(Rate other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Amount == other.Amount && Equals(Frequency, other.Frequency);
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

            return Equals((Rate)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode() * 397) ^ (Frequency != null ? Frequency.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return Amount + "/" + Frequency;
        }
    }
}
