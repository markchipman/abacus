namespace Abacus.Domain
{
    public static class StandardDayRollConvention
    {
        static StandardDayRollConvention()
        {
        }

        public static readonly DayRollConvention _None = new DayRollConvention_None();
        public static readonly DayRollConvention _EndOfMonth = new DayRollConvention_EndOfMonth();
        public static readonly DayRollConvention _IMM = new DayRollConvention_IMM();
    }
}
