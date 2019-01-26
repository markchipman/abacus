namespace Abacus.Domain
{
    public static class StandardDayCount
    {
        static StandardDayCount()
        {
        }

        public static readonly DayCountConvention _Actual_360 = new DayCountConvention_Actual_360();
        public static readonly DayCountConvention _Actual_365F = new DayCountConvention_Actual_365F();
        public static readonly DayCountConvention _Actual_364 = new DayCountConvention_Actual_364();
        public static readonly DayCountConvention _30A_360 = new DayCountConvention_30A_360();
        public static readonly DayCountConvention _30U_360 = new DayCountConvention_30U_360();
        public static readonly DayCountConvention _30E_360 = new DayCountConvention_30E_360();
        public static readonly DayCountConvention _30EPlus_360 = new DayCountConvention_30EPlus_360();
    }
}
