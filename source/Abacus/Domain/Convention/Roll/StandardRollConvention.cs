namespace Abacus.Domain
{
    public static class StandardRollConvention
    {
        public static readonly RollConvention _None = RollConvention_None.Instance;
        public static readonly RollConvention _EOM = RollConvention_EOM.Instance;
        public static readonly RollConvention _IMM = RollConvention_IMM.Instance;
    }
}
