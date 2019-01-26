namespace Abacus.Domain
{
    public static class StandardDayAdjustment
    {
        static StandardDayAdjustment()
        {
        }

        public static readonly DayAdjustmentConvention _None = new DayAdjustmentConvention_None();
        public static readonly DayAdjustmentConvention _Following = new DayAdjustmentConvention_Following();
        public static readonly DayAdjustmentConvention _ModifiedFollowing = new DayAdjustmentConvention_ModifiedFollowing();
    }
}
