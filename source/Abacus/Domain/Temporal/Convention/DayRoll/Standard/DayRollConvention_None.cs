using System;

namespace Abacus.Domain
{
    internal sealed class DayRollConvention_None : DayRollConvention
    {
        public override bool IsRollDate(DateTime date) => true;

        public override DateTime NextRoll(DateTime date) => date;
    }
}
