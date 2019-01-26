using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abacus.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Controllers
{
    [ApiController]
    [Route("api/convention")]
    public class ConventionController : ControllerBase
    {
        private readonly IReadOnlyDictionary<string, HolidayCalendar> _holidayCalendarRegistry = new Dictionary<string, HolidayCalendar>(StringComparer.OrdinalIgnoreCase)
        {
            ["none"] = StandardHolidayCalendar._None,
            ["sat-sun"] = StandardHolidayCalendar._Sat_Sun
        };
        private readonly IReadOnlyDictionary<string, DayAdjustmentConvention> _dayAdjustRegistry = new Dictionary<string, DayAdjustmentConvention>(StringComparer.OrdinalIgnoreCase)
        {
            ["f"] = StandardDayAdjustment._Following,
            ["mf"] = StandardDayAdjustment._ModifiedFollowing
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

        [HttpGet("adjust/{conventionId}/{date}/{calendarId?}")]
        public IActionResult DayAdjustment(DayAdjustmentParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.CalendarId, out var calendar))
                {
                    return NotFound(nameof(param.CalendarId) + ": " + param.CalendarId);
                }
                if (!_dayAdjustRegistry.TryGetValue(param.ConventionId, out var convention))
                {
                    return NotFound(nameof(param.ConventionId) + ": " + param.ConventionId);
                }
                var result = convention.Adjust(param.Date, calendar);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
    public class HolidayParam
    {
        [FromRoute]
        [Required]
        public string CalendarId { get; set; } = "none";

        [FromRoute]
        [Required]
        public DateTime Date { get; set; }
    }
    public class DayAdjustmentParam
    {
        [FromRoute]
        [Required]
        public string ConventionId { get; set; } = "none";

        [FromRoute]
        [Required]
        public DateTime Date { get; set; }

        [FromRoute]
        public string CalendarId { get; set; } = "none";
    }
}
