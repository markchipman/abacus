using System;

namespace Abacus.Domain
{
    public sealed class RollConvention_None : RollConvention<RollConvention_None>
    {
        /// <summary>
        /// No roll, roll convention.
        ///
        /// Does not roll date.
        /// </summary>
        public RollConvention_None()
                    : base("NONE")
        {
        }

        public override DateTime Roll(DateTime date) => date;
    }
}
