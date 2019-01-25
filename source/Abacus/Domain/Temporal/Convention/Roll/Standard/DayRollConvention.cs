using System;

namespace Abacus.Domain
{
    public class DayRollConvention : RollConvention
    {
        private readonly int dayOfMonth;

        public DayRollConvention(int dayOfMonth)
        {
            this.dayOfMonth = dayOfMonth;
        }

        public override bool Matches(DateTime date)
        {
            return date.Day == dayOfMonth;
        }

        public override DateTime Roll(DateTime date)
        {
            var result = Matches(date) ? date : RollForward(date);
            return result;
        }

        public override DateTime RollBackward(DateTime date)
        {
            throw new NotImplementedException();
        }

        public override DateTime RollForward(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
