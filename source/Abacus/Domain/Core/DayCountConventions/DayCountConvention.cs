using System;

namespace Abacus.Domain
{
    public abstract class DayCountConvention
    {
        public abstract decimal CountDays(DateTime startDate, DateTime endDate);
    }
}
