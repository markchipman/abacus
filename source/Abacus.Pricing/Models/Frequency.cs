namespace Abacus.Pricing.Models
{
    public class Frequency
    {
        public static readonly Frequency Annually = new Frequency { TimesAYear = 1 };
        public static readonly Frequency SemiAnnually = new Frequency { TimesAYear = 2 };
        public static readonly Frequency Quarterly = new Frequency { TimesAYear = 4 };
        public static readonly Frequency Monthly = new Frequency { TimesAYear = 12 };
        public static readonly Frequency Weekly = new Frequency { TimesAYear = 52 };

        public decimal TimesAYear { get; protected set; }

        public decimal YearFraction
        {
            get { return 1 / TimesAYear; }
        }
    }
}