using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_None : RollConvention
    {
        public override DateTime Roll(DateTime date) => date;
    }
}
