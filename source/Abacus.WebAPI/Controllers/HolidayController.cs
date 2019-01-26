using System;
using System.Collections.Generic;
using Abacus.Domain;
using Abacus.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Controllers
{
    [ApiController]
    [Route("api/holiday")]
    public class HolidayController : ControllerBase
    {
        private readonly IReadOnlyDictionary<string, HolidayCalendar> _holidayCalendarRegistry = new Dictionary<string, HolidayCalendar>(StringComparer.OrdinalIgnoreCase)
        {
            ["none"] = StandardHolidayCalendar._None,
            ["sat-sun"] = StandardHolidayCalendar._Sat_Sun
        };


        [HttpGet("is-holiday/{date}/{calendarId?}")]
        public IActionResult IsHoliday(HolidayParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.CalendarId, out var calendar))
                {
                    return NotFound(nameof(param.CalendarId) + ": " + param.CalendarId);
                }
                var result = calendar.IsHoliday(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("not-holiday/{date}/{calendarId?}")]
        public IActionResult IsNotHoliday(HolidayParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.CalendarId, out var calendar))
                {
                    return NotFound(nameof(param.CalendarId) + ": " + param.CalendarId);
                }
                var result = calendar.IsNotHoliday(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("next-holiday/{date}/{calendarId?}")]
        public IActionResult NextHoliday(HolidayParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.CalendarId, out var calendar))
                {
                    return NotFound(nameof(param.CalendarId) + ": " + param.CalendarId);
                }
                var result = calendar.NextHoliday(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("next-nonholiday/{date}/{calendarId?}")]
        public IActionResult NextNonHoliday(HolidayParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.CalendarId, out var calendar))
                {
                    return NotFound(nameof(param.CalendarId) + ": " + param.CalendarId);
                }
                var result = calendar.NextNonHoliday(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("prev-holiday/{date}/{calendarId?}")]
        public IActionResult PreviousHoliday(HolidayParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.CalendarId, out var calendar))
                {
                    return NotFound(nameof(param.CalendarId) + ": " + param.CalendarId);
                }
                var result = calendar.PreviousHoliday(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("prev-nonholiday/{date}/{calendarId?}")]
        public IActionResult PreviousNonHoliday(HolidayParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.CalendarId, out var calendar))
                {
                    return NotFound(nameof(param.CalendarId) + ": " + param.CalendarId);
                }
                var result = calendar.PreviousNonHoliday(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
