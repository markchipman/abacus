using System;

namespace Abacus.Domain
{
    internal sealed class DayAdjustmentConvention_F : DayAdjustmentConvention
    {
        protected override DateTime DoAdjust(DateTime date, HolidayCalendar calendar)
        {
            if (calendar == null)
            {
                throw new ArgumentNullException(nameof(calendar));
            }

            var result = Adjust(date.AddDays(1), calendar);
            return result;
        }
    }
}
