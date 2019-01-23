namespace Abacus.Domain
{
    public static class StandardRollConvention
    {
        static StandardRollConvention()
        {
        }

        public static readonly RollConvention _None = new RollConvention_None();
        public static readonly RollConvention _EOM = new RollConvention_EOM();
        public static readonly RollConvention _IMM = new RollConvention_IMM();
    }
}
