namespace Abacus.Domain
{
    public static class StandardHolidayCalendar
    {
        static StandardHolidayCalendar()
        {
        }

        public static readonly HolidayCalendar _SAT_SUN = new HolidayCalendar_SAT_SUN();
    }
}
