namespace Abacus.Domain
{
    public static class StandardHolidayCalendar
    {
        static StandardHolidayCalendar()
        {
        }

        public static readonly HolidayCalendar _None = new HolidayCalendar_None();
        public static readonly HolidayCalendar _Sat_Sun = new HolidayCalendar_Sat_Sun();
    }
}
