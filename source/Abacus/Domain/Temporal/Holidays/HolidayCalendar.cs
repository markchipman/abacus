using System;

namespace Abacus.Domain
{
    public abstract class HolidayCalendar
    {
        public abstract bool IsHoliday(DateTime date);

        public virtual bool IsNotHoliday(DateTime date) => !IsHoliday(date);

        public abstract DateTime? NextHoliday(DateTime date);

        public abstract DateTime? NextNonHoliday(DateTime date);

        public abstract DateTime? PreviousHoliday(DateTime date);

        public abstract DateTime? PreviousNonHoliday(DateTime date);
    }
}
