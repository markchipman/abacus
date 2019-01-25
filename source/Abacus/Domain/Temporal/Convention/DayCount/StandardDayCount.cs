namespace Abacus.Domain
{
    public static class StandardDayCount
    {
        static StandardDayCount()
        {
        }

        public static readonly DayCountConvention _ACT_360 = new DayCountConvention_ACT_360();
        public static readonly DayCountConvention _ACT_365F = new DayCountConvention_ACT_365F();
        public static readonly DayCountConvention _ACT_364 = new DayCountConvention_ACT_364();
        public static readonly DayCountConvention _30A_360 = new DayCountConvention_30A_360();
        public static readonly DayCountConvention _30U_360 = new DayCountConvention_30U_360();
        public static readonly DayCountConvention _30E_360 = new DayCountConvention_30E_360();
        public static readonly DayCountConvention _30EPLUS_360 = new DayCountConvention_30EPLUS_360();
    }
}
