using System;
using Abacus.Enums;

namespace Abacus.Domain
{
    public abstract class DayCountConvention<TSelf> : DayCountConvention where TSelf : DayCountConvention<TSelf>, new()
    {
        public static readonly TSelf Instance = new TSelf();

        protected DayCountConvention(string id)
            : base(id)
        {
        }
    }

    public abstract class DayCountConvention : Enumeration<string>
    {
        protected DayCountConvention(string id)
            : base(id)
        {
        }

        public abstract decimal CountDays(DateTime startDate, DateTime endDate);
    }
}
