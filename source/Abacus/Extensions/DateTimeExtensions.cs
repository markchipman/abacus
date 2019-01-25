namespace System
{
    public static class DateTimeExtensions
    {
        public static DateTime AddWeeks(this DateTime date, int weeks)
        {
            var result = date.AddDays(weeks * 7);
            return result;
        }

        public static int MonthsApart(this DateTime startDate, DateTime endDate)
        {
            var monthsApart = (12 * (startDate.Year - endDate.Year)) + (startDate.Month - endDate.Month);
            return Math.Abs(monthsApart);
        }

        public static DateTime ClosestDayOfWeek(this DateTime date, DayOfWeek dayOfWeek, int weeks = 0)
        {
            var nextDayOfWeek = date.AddDays(((int)dayOfWeek) - ((int)date.DayOfWeek) + (7 * weeks));
            return nextDayOfWeek;
        }

        public static bool IsLastDayOfMonth(this DateTime date)
        {
            var IsLastDayOfMonth = date.AddDays(1).Month == date.Month + 1;
            return IsLastDayOfMonth;
        }

        public static bool IsLastDayOfFebruary(this DateTime date)
        {
            var isLastDayOfFebruary = date.Month == 2 && date.IsLastDayOfMonth();
            return isLastDayOfFebruary;
        }

        public static bool IsLeapDay(this DateTime date)
        {
            var isLeapDay = date.Month == 2 && date.Day == 29 && DateTime.IsLeapYear(date.Year);
            return isLeapDay;
        }

        public static int CountLeapDays(this DateTime startDate, DateTime endDate)
        {
            var nonLeapDays = 365 * (endDate.Year - startDate.Year);
            var leapDays = (endDate - startDate).Days - nonLeapDays;
            return leapDays;
        }
    }
}
