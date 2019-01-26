using System;

namespace Abacus.Domain
{
    internal sealed class DayAdjustmentConvention_None : DayAdjustmentConvention
    {
        protected override DateTime DoAdjust(DateTime date, HolidayCalendar calendar) => date;
    }
}
