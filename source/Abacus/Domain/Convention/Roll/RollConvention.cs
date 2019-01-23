using System;
using Abacus.Enums;

namespace Abacus.Domain
{
    /// <summary>
    /// Rolls a date by a market convention.
    /// </summary>
    public abstract class RollConvention
    {
        /// <summary>
        /// Rolls t
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public abstract DateTime Roll(DateTime date); // TODO - use calendar
    }
}
