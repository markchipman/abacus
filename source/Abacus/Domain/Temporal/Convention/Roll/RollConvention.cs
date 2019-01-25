using System;

namespace Abacus.Domain
{
    public abstract class RollConvention
    {
        public abstract bool IsEOM { get; }

        public virtual bool Matches(DateTime date)
        {
            var adjustedDate = Roll(date);
            return adjustedDate == date;
        }

        public abstract DateTime Roll(DateTime date);

        public abstract DateTime RollForward(DateTime date);

        public abstract DateTime RollBackward(DateTime date);
    }
}
