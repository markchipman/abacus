using System;

namespace Abacus.Domain
{
    public abstract class RollConvention
    {
        public virtual bool IsEOM { get; } = false;

        public virtual DateTime Roll(DateTime date)
        {
            var result = NeedsRoll(date) ? DoRoll(date) : date;
            return result;
        }

        protected abstract bool NeedsRoll(DateTime date);

        protected abstract DateTime DoRoll(DateTime date);
    }
}
