using System;
using Abacus.Enums;

namespace Abacus.Domain
{
    /// <summary>
    /// Rolls a date by a market convention.
    /// </summary>
    /// <typeparam name="TSelf">The implementing class type.</typeparam>
    public abstract class RollConvention<TSelf> : RollConvention where TSelf : RollConvention<TSelf>, new()
    {
        public static readonly TSelf Instance = new TSelf();

        protected RollConvention(string id)
            : base(id)
        {
        }
    }

    /// <summary>
    /// Rolls a date by a market convention.
    /// </summary>
    public abstract class RollConvention : Enumeration<string>
    {
        protected RollConvention(string id)
            : base(id)
        {
        }

        /// <summary>
        /// Rolls t
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public abstract DateTime Roll(DateTime date);
    }
}
