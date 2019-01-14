using System;
using Abacus.Enums;

namespace Abacus.Domain
{
    public abstract class DayCountConvention : Enumeration<string>
    {
        protected DayCountConvention(string id)
            : base(id)
        {
        }

        public abstract decimal CountDays(DateTime startDate, DateTime endDate);
    }
}
