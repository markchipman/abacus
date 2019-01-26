using System;

namespace Abacus.Domain
{
    public abstract class DayAdjustmentConvention
    {
        public virtual DateTime Adjust(DateTime date, HolidayCalendar calendar)
        {
            if (NeedsAdjust(date, calendar))
            {
                var result = DoAdjust(date, calendar);
                return result;
            }
            else
            {
                return date;
            }
        }

        protected virtual bool NeedsAdjust(DateTime date, HolidayCalendar calendar)
        {
            var needsAdj = calendar.IsHoliday(date);
            return needsAdj;
        }

        protected abstract DateTime DoAdjust(DateTime date, HolidayCalendar calendar);
    }
}
