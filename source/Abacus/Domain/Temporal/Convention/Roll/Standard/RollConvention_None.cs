using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_None : RollConvention
    {
        public override bool IsEOM => false;

        public override DateTime Roll(DateTime date) => date;

        public override DateTime RollForward(DateTime date) => date;

        public override DateTime RollBackward(DateTime date) => date;
    }
}
