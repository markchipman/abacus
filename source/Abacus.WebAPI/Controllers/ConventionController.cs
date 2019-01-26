using System;
using System.Collections.Generic;
using Abacus.Domain;
using Abacus.WebApi.Models;
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
}
