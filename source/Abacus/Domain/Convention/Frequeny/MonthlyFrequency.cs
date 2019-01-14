using System;

namespace Abacus.Domain
{
    public class MonthlyFrequency : Frequency<MonthlyFrequency>
    {
        public MonthlyFrequency()
            : base("M")
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddMonths(1);
        }
    }
}
