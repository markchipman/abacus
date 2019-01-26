﻿using System;

namespace Abacus.Domain
{
    internal sealed class HolidayCalendar_None : HolidayCalendar
    {
        public override bool IsHoliday(DateTime date) => false;

        public override DateTime? NextHoliday(DateTime date) => default;

        public override DateTime? NextNonHoliday(DateTime date) => default;

        public override DateTime? PreviousHoliday(DateTime date) => default;

        public override DateTime? PreviousNonHoliday(DateTime date) => default;
    }
}
