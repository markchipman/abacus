using System;

namespace Abacus.Domain
{
    public class AnnuallyFrequency : Frequency
    {
        public static readonly AnnuallyFrequency Instance = new AnnuallyFrequency();

        static AnnuallyFrequency()
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddYears(1);
        }
    }
}
