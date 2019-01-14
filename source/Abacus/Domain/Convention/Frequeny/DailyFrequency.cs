using System;

namespace Abacus.Domain
{
    public class DailyFrequency : Frequency<DailyFrequency>
    {
        public DailyFrequency()
            : base("D")
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddDays(1);
        }
    }
}
