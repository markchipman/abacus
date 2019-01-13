using System.Collections;
using System.Collections.Generic;

namespace Abacus.Domain
{
    public abstract class Schedule<TPeriod> : IReadOnlyList<TPeriod> where TPeriod : Period
    {
        protected Schedule()
        {
        }

        protected Schedule(IEnumerable<TPeriod> periods)
        {
            if (periods == null)
            {
                throw new System.ArgumentNullException(nameof(periods));
            }

            Periods.AddRange(periods);
        }

        protected List<TPeriod> Periods { get; } = new List<TPeriod>();

        public TPeriod this[int index] => Periods[index];

        public int Count => Periods.Count;

        public IEnumerator<TPeriod> GetEnumerator() => Periods.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
