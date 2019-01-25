using System;

namespace Abacus.Domain
{
    public abstract class DayAdjustmentConvention
    {
        public abstract DateTime Adjust(DateTime date, HolidayCalendar calendar);
    }
}
