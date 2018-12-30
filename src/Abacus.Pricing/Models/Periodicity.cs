namespace Abacus.Pricing.Models
{
    public class Periodicity
    {
        public decimal YearFraction { get; protected set; }

        public static readonly Periodicity Annually = new Periodicity { YearFraction = 1 };
        public static readonly Periodicity SemiAnnually = new Periodicity { YearFraction = 1 / 2 };
        public static readonly Periodicity Quarterly = new Periodicity { YearFraction = 1 / 4 };
        public static readonly Periodicity Monthly = new Periodicity { YearFraction = 1 / 12 };
        public static readonly Periodicity Weekly = new Periodicity { YearFraction = 1 / 52 };
    }
}