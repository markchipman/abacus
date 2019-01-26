namespace Abacus.Domain
{
    public static class StandardRollConvention
    {
        static StandardRollConvention()
        {
        }

        public static readonly RollConvention _None = new RollConvention_None();
        public static readonly RollConvention _EndOfMonth = new RollConvention_EndOfMonth();
        public static readonly RollConvention _IMM = new RollConvention_IMM();
    }
}
