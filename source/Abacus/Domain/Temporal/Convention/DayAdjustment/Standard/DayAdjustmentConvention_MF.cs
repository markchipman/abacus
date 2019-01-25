using System;

namespace Abacus.Domain
{
    internal sealed class DayAdjustmentConvention_MF : DayAdjustmentConvention
    {
        public override DateTime Adjust(DateTime date, HolidayCalendar calendar)
        {
            if (calendar == null)
            {
                throw new ArgumentNullException(nameof(calendar));
            }

            if (calendar.IsHoliday(date))
            {
                var adjusted = Adjust(date.AddDays(1), calendar);
                if (adjusted.Month != date.Month)
                {
                    var result = Adjust(date.AddDays(-1), calendar);
                    return result;
                }
                else
                {
                    return adjusted;
                }
            }
            else
            {
                return date;
            }
        }
    }
}
