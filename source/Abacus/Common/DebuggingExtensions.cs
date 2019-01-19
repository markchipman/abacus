using System;
using Abacus.Common;

namespace Abacus.Debugging
{
    public static class DebuggingExtensions
    {
        public static string DebugToString(this DateTime? date, string nullValue = null)
        {
            return date.HasValue ? DebugToString(date.Value) : nullValue;
        }

        public static string DebugToString(this DateTime date)
        {
            return date.ToString(DebuggingConstants.ToStringDateFormat);
        }

        public static string DebugToStringDateRange(this DateTime startDate, DateTime endDate)
        {
            var totalDays = (endDate - startDate).TotalDays;

            if (totalDays % 365 < 30)
            {
                var years = Math.Round(totalDays / 365);
                return "~" + years + "Y";
            }
            else if (totalDays >= 28)
            {
                var months = startDate.MonthsApart(endDate);
                return "~" + months + "M";
            }
            else
            {
                var days = (endDate - startDate).Days;
                return "~" + days + "D";
            }
        }
    }
}
