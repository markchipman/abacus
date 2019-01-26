using System;

namespace Abacus.Domain
{
    public class TimeDuration : IEquatable<TimeDuration>
    {
        public TimeDuration(int years = 0, int months = 0, int weeks = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0, int milliseconds = 0)
        {
            if (years < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(years) + " must be a whole number");
            }
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(months) + " must be a whole number");
            }
            if (weeks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weeks) + " must be a whole number");
            }
            if (days < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(days) + " must be a whole number");
            }
            if (hours < 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(hours) + " must be a whole number");
            }
            if (minutes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minutes) + " must be a whole number");
            }
            if (seconds < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(seconds) + " must be a whole number");
            }
            if (milliseconds < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(milliseconds) + " must be a whole number");
            }

            Years = years;
            Months = months;
            Weeks = weeks;
            Days = days;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = milliseconds;
        }

        public int Years { get; }

        public int Months { get; }

        public int Weeks { get; }

        public int Days { get; }

        public int Hours { get; }

        public int Minutes { get; }

        public int Seconds { get; }

        public int Milliseconds { get; }

        public bool Equals(TimeDuration other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Years, Months, Weeks, Days, Hours, Minutes, Seconds, Milliseconds);
        }

        public override string ToString()
        {
            return Years + "y " + Months + "m " + Weeks + "w " + Days + "d " + Hours + "hr " + Minutes + "min " + Seconds + "sec " + Milliseconds + "ms";
        }

        public static TimeDuration InYears(int amount) => new TimeDuration(years: amount);

        public static TimeDuration InMonths(int amount) => new TimeDuration(months: amount);

        public static TimeDuration InWeeks(int amount) => new TimeDuration(weeks: amount);

        public static TimeDuration InDays(int amount) => new TimeDuration(days: amount);

        public static TimeDuration InHours(int amount) => new TimeDuration(hours: amount);

        public static TimeDuration InMinutes(int amount) => new TimeDuration(minutes: amount);

        public static TimeDuration InSeconds(int amount) => new TimeDuration(seconds: amount);

        public static TimeDuration InMilliseconds(int amount) => new TimeDuration(milliseconds: amount);
    }
}
