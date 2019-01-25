using System;

namespace Abacus.Domain
{
    public abstract class RollConvention
    {
        public virtual bool IsEOM { get; } = false;

        public abstract bool Matches(DateTime date);

        public abstract DateTime Roll(DateTime date);

        public abstract DateTime RollForward(DateTime date);

        public abstract DateTime RollBackward(DateTime date);
    }
}
