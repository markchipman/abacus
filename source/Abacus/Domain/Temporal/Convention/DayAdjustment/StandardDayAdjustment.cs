namespace Abacus.Domain
{
    public static class StandardDayAdjustment
    {
        static StandardDayAdjustment()
        {
        }

        public static readonly DayAdjustmentConvention _F = new DayAdjustmentConvention_F();
        public static readonly DayAdjustmentConvention _MF = new DayAdjustmentConvention_MF();
    }
}
