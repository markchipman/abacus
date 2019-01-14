using System;
using Abacus.Enums;

namespace Abacus.Domain
{
    public abstract class RollConvention : Enumeration<string>
    {
        protected RollConvention(string id)
            : base(id)
        {
        }

        public abstract DateTime Adjust(DateTime date);
    }
}
