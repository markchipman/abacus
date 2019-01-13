using System;

namespace Abacus.Domain
{
    public abstract class RollConvention
    {
        public abstract DateTime Adjust(DateTime date);
    }
}
