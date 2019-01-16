using System;

namespace Abacus.Domain
{
    public sealed class NoneRollConvention : RollConvention<NoneRollConvention>
    {
        /// <summary>
        /// No roll, roll convention.
        ///
        /// Does not roll date.
        /// </summary>
        public NoneRollConvention()
                    : base("NONE")
        {
        }

        public sealed override DateTime Roll(DateTime date) => date;
    }
}
