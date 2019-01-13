using System;

namespace Abacus.Domain
{
    public class MonthlyFrequency : Frequency
    {
        public static readonly MonthlyFrequency Instance = new MonthlyFrequency();

        static MonthlyFrequency()
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddMonths(1);
        }
    }
}
