using System;

namespace Abacus.Domain
{
    public class QuarterlyFrequency : Frequency
    {
        public static readonly QuarterlyFrequency Instance = new QuarterlyFrequency();

        static QuarterlyFrequency()
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddMonths(3);
        }
    }
}
