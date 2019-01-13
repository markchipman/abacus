using System;

namespace Abacus.Domain
{
    public class DailyFrequency : Frequency
    {
        public static readonly DailyFrequency Instance = new DailyFrequency();

        static DailyFrequency()
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddDays(1);
        }
    }
}
