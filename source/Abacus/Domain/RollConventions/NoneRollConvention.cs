using System;

namespace Abacus.Domain
{
    public class NoneRollConvention : RollConvention
    {
        public static readonly NoneRollConvention Instance = new NoneRollConvention();

        static NoneRollConvention()
        {
        }

        public NoneRollConvention()
            : base("NONE")
        {
        }

        public override DateTime Adjust(DateTime date)
        {
            return date;
        }
    }
}
