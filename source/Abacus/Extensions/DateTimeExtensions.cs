namespace System
{
    public static class DateTimeExtensions
    {
        public static int MonthsApart(this DateTime startDate, DateTime endDate)
        {
            var monthsApart = (12 * (startDate.Year - endDate.Year)) + (startDate.Month - endDate.Month);
            return Math.Abs(monthsApart);
        }

        public static bool IsLastDayOfMonth(this DateTime date)
        {
            return date.AddDays(1).Month == date.Month + 1;
        }

        public static bool IsLastDayOfFebruary(this DateTime date)
        {
            return date.Month == 2 && date.IsLastDayOfMonth();
        }

        public static bool IsLeapDay(this DateTime date)
        {
            return date.Month == 2 && date.Day == 29 && DateTime.IsLeapYear(date.Year);
        }

        public static int CountLeapDays(this DateTime startDate, DateTime endDate)
        {
            var nonLeapDays = 365 * (endDate.Year - startDate.Year);
            var leapDays = (endDate - startDate).Days - nonLeapDays;
            return leapDays;
        }
    }
}
