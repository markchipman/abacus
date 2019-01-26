using System;

namespace Abacus.Domain
{
    internal sealed class DayAdjustmentConvention_ModifiedFollowing : DayAdjustmentConvention
    {
        protected override DateTime DoAdjust(DateTime date, HolidayCalendar calendar)
        {
            if (calendar == null)
            {
                throw new ArgumentNullException(nameof(calendar));
            }

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
    }
}
