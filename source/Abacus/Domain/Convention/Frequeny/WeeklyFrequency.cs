using System;

namespace Abacus.Domain
{
    public class WeeklyFrequency : Frequency
    {
        public static readonly WeeklyFrequency Instance = new WeeklyFrequency();

        static WeeklyFrequency()
        {
        }

        public WeeklyFrequency()
            : base("W")
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddDays(7);
        }
    }
}
