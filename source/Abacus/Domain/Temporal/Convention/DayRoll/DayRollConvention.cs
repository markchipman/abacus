using System;

namespace Abacus.Domain
{
    public abstract class DayRollConvention
    {
        public virtual bool IsEOM { get; } = false;

        public virtual DateTime Roll(DateTime date)
        {
            var result = IsRollDate(date) ? date : NextRoll(date);
            return result;
        }

        public abstract bool IsRollDate(DateTime date);

        public abstract DateTime NextRoll(DateTime date);
    }
}
