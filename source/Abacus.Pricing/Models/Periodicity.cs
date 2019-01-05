namespace Abacus.Pricing.Models
{
    public class Periodicity
    {
        public static readonly Periodicity PerYear = new Periodicity { YearFraction =  1 / 1 };
        public static readonly Periodicity PerHalfYear = new Periodicity { YearFraction = 1 / 2 };
        public static readonly Periodicity PerQuarty = new Periodicity { YearFraction = 1 / 4 };
        public static readonly Periodicity PerMonth = new Periodicity { YearFraction = 1 / 12 };
        public static readonly Periodicity PerWeek = new Periodicity { YearFraction = 1 / 52 };

        public decimal YearFraction { get; protected set; }

        public decimal TimesAYear
        {
            get { return 1 / YearFraction; }
        }
    }
}
