using System;

namespace Abacus.Domain
{
    public abstract class Frequency
    {
        public abstract DateTime Next(DateTime date);
    }
}
