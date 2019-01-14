using System;

namespace Abacus.Domain
{
    public class AnnuallyFrequency : Frequency<AnnuallyFrequency>
    {
        public AnnuallyFrequency()
            : base("A")
        {
        }

        public override DateTime NextEventDate(DateTime date)
        {
            return date.AddYears(1);
        }
    }
}
