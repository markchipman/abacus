namespace Abacus.Domain
{
    public static class StandardFrequency
    {
        static StandardFrequency()
        {
        }

        public static readonly Frequency _Annually = new Frequency_Annually();
        public static readonly Frequency _SemiAnnually = new Frequency_SemiAnnually();
        public static readonly Frequency _Quarterly = new Frequency_Quarterly();
        public static readonly Frequency _Monthly = new Frequency_Monthly();
        public static readonly Frequency _Weekly = new Frequency_Weekly();
        public static readonly Frequency _Daily = new Frequency_Daily();
        public static readonly Frequency _Once = new Frequency_Once();
    }
}
