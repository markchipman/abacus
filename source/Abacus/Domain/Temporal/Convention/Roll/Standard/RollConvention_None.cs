using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_None : RollConvention
    {
        protected override bool NeedsRoll(DateTime date) => false;

        protected override DateTime DoRoll(DateTime date) => date;
    }
}
