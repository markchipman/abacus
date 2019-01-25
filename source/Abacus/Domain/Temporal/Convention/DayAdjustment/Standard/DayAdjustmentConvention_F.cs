using System;

namespace Abacus.Domain
{
    internal sealed class DayAdjustmentConvention_F : DayAdjustmentConvention
    {
        public override DateTime Adjust(DateTime date, HolidayCalendar calendar)
        {
            if (calendar == null)
            {
                throw new ArgumentNullException(nameof(calendar));
            }

            var result = calendar.IsHoliday(date) ? Adjust(date.AddDays(1), calendar) : date;
            return result;
        }
    }
}
