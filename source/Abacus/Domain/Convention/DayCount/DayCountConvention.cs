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

        public abstract decimal YearFraction(DateTime startDate, DateTime endDate, DateTime paymentDate);

        protected static int CalculateNumerator30360(int y1, int m1, int d1, int y2, int m2, int d2)
        {
            return d2 - d1 + (30 * (m2 - m1)) + (360 * (y2 - y1));
        }
    }
}
