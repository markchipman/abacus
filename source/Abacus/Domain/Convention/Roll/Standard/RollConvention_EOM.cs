using System;

namespace Abacus.Domain
{
    internal sealed class RollConvention_EOM : RollConvention
    {
        public override DateTime Roll(DateTime date) => new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }
}
