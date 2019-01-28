using System;

namespace Abacus.Domain
{
    public abstract class HolidayCalendar
    {
        public abstract bool IsHoliday(DateTime date);

        public virtual bool IsNotHoliday(DateTime date) => !IsHoliday(date);

        public DateTime? NextHoliday(DateTime date, bool includeDate = false)
        {
            var result = includeDate && IsHoliday(date) ? date : NextHoliday(date);
            return result;
        }

        public DateTime? NextNonHoliday(DateTime date, bool includeDate = false)
        {
            var result = includeDate && IsNotHoliday(date) ? date : NextNonHoliday(date);
            return result;
        }

        public DateTime? PreviousHoliday(DateTime date, bool includeDate = false)
        {
            var result = includeDate && IsHoliday(date) ? date : PreviousHoliday(date);
            return result;
        }

        public DateTime? PreviousNonHoliday(DateTime date, bool includeDate = false)
        {
            var result = includeDate && IsNotHoliday(date) ? date : PreviousNonHoliday(date);
            return result;
        }

        public abstract DateTime? NextHoliday(DateTime date);

        public abstract DateTime? NextNonHoliday(DateTime date);

        public abstract DateTime? PreviousHoliday(DateTime date);

        public abstract DateTime? PreviousNonHoliday(DateTime date);
    }
}
