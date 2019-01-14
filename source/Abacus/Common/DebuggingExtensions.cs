using System;
using Abacus.Common;

namespace Abacus.Debugging
{
    public static class DebuggingExtensions
    {
        public static string DebugToString(this DateTime? date, string nullValue = null)
        {
            return date.HasValue ? DebugToString(date.Value) : nullValue;
        }

        public static string DebugToString(this DateTime date)
        {
            return date.ToString(DebuggingConstants.ToStringDateFormat);
        }
    }
}
