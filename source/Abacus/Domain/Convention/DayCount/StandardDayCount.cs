namespace Abacus.Domain
{
    public static class StandardDayCount
    {
        public static readonly DayCountConvention _ACT_360 = DayCountConvention_ACT_360.Instance;
        public static readonly DayCountConvention _ACT_365F = DayCountConvention_ACT_365F.Instance;
        public static readonly DayCountConvention _ACT_364 = DayCountConvention_ACT_364.Instance;
        public static readonly DayCountConvention _A30_360 = DayCountConvention_30A_360.Instance;
        public static readonly DayCountConvention _30U_360 = DayCountConvention_30U_360.Instance;
        public static readonly DayCountConvention _30E_360 = DayCountConvention_30E_360.Instance;
        public static readonly DayCountConvention _30EPLUS_360 = DayCountConvention_30EPLUS_360.Instance;
    }
}
