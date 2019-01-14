using System;

namespace Abacus.Domain
{
    public class QuarterlyFrequency : Frequency<QuarterlyFrequency>
    {
        public QuarterlyFrequency()
            : base("Q")
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddMonths(3);
        }
    }
}
