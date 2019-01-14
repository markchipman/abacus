using System;

namespace Abacus.Domain
{
    public class SemiAnnuallyFrequency : Frequency
    {
        public static readonly SemiAnnuallyFrequency Instance = new SemiAnnuallyFrequency();

        static SemiAnnuallyFrequency()
        {
        }

        public SemiAnnuallyFrequency()
            : base("S")
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddMonths(6);
        }
    }
}
