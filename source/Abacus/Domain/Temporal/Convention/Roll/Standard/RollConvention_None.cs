using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_None : RollConvention
    {
        public override bool Matches(DateTime date) => true;

        public override DateTime Roll(DateTime date) => date;

        public override DateTime RollForward(DateTime date) => date;

        public override DateTime RollBackward(DateTime date) => date;
    }
}
