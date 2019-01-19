namespace Abacus.Domain
{
    public static class StandardFrequency
    {
        public static readonly Frequency _Annually = Frequency_Annual.Instance;
        public static readonly Frequency _SemiAnnually = Frequency_SemiAnnual.Instance;
        public static readonly Frequency _Quarterly = Frequency_Quarterly.Instance;
        public static readonly Frequency _Monthly = Frequency_Monthly.Instance;
        public static readonly Frequency _Weekly = Frequency_Weekly.Instance;
        public static readonly Frequency _Daily = Frequency_Daily.Instance;
    }
}
