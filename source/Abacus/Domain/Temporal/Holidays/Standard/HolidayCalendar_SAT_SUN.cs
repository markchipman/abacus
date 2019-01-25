﻿using System;

namespace Abacus.Domain
{
    public class HolidayCalendar_SAT_SUN : HolidayCalendar
    {
        public override bool IsHoliday(DateTime date)
        {
            var isHoliday = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
            return isHoliday;
        }

        public override DateTime NextHoliday(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                var next = date.AddDays(1);
                return next;
            }
            else
            {
                var next = date.ClosestDayOfWeek(DayOfWeek.Saturday, +1);
                return next;
            }
        }

        public override DateTime NextNonHoliday(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Friday)
            {
                var next = date.AddDays(3);
                return next;
            }
            else if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                var next = date.AddDays(2);
                return next;
            }
            else
            {
                return date.AddDays(1);
            }
        }

        public override DateTime PreviousHoliday(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                var next = date.AddDays(-1);
                return next;
            }
            else
            {
                var next = date.AddDays(-7);
                return next;
            }
        }

        public override DateTime PreviousNonHoliday(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                var next = date.AddDays(-2);
                return next;
            }
            else
            {
                var next = date.AddDays(-1);
                return next;
            }
        }
    }
}
