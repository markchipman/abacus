using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Abacus.Domain
{
    public class Schedule<TPeriod> : ReadOnlyCollection<TPeriod>
    {
        public static readonly Schedule<TPeriod> Empty = new Schedule<TPeriod>();

        static Schedule()
        {
        }

        public Schedule()
            : base(new List<TPeriod>())
        {
        }

        public Schedule(IList<TPeriod> list)
            : base(list)
        {
        }
    }
}
