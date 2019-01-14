using System;

namespace Abacus.Domain
{
    public class WeeklyFrequency : Frequency<WeeklyFrequency>
    {
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
