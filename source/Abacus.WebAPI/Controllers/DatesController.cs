using System;
using System.Collections.Generic;
using Abacus.Domain;
using Abacus.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Controllers
{
    [ApiController]
    [Route("api/dates")]
    public class DatesController : ControllerBase
    {
        private readonly IReadOnlyDictionary<string, HolidayCalendar> _holidayCalendarRegistry = new Dictionary<string, HolidayCalendar>(StringComparer.OrdinalIgnoreCase)
        {
            ["none"] = StandardHolidayCalendar._None,
            ["sat-sun"] = StandardHolidayCalendar._Sat_Sun
        };
        private readonly IReadOnlyDictionary<string, DayAdjustmentConvention> _dayAdjustmentConventionRegistry = new Dictionary<string, DayAdjustmentConvention>(StringComparer.OrdinalIgnoreCase)
        {
            ["none"] = StandardDayAdjustment._None,
            ["f"] = StandardDayAdjustment._Following,
            ["mf"] = StandardDayAdjustment._ModifiedFollowing
        };
        private readonly IReadOnlyDictionary<string, DayCountConvention> _dayCountConventionRegistry = new Dictionary<string, DayCountConvention>(StringComparer.OrdinalIgnoreCase)
        {
            ["act-360"] = StandardDayCount._Actual_360,
            ["act-365f"] = StandardDayCount._Actual_365F,
            ["act-364"] = StandardDayCount._Actual_364,
            ["30a-360"] = StandardDayCount._30A_360,
            ["30u-360"] = StandardDayCount._30U_360,
            ["30e-360"] = StandardDayCount._30E_360,
            ["30eplus-360"] = StandardDayCount._30EPlus_360,
        };
        private readonly IReadOnlyDictionary<string, DayRollConvention> _dayRollConventionRegistry = new Dictionary<string, DayRollConvention>(StringComparer.OrdinalIgnoreCase)
        {
            ["none"] = StandardDayRollConvention._None,
            ["imm"] = StandardDayRollConvention._IMM,
            ["eom"] = StandardDayRollConvention._EndOfMonth
        };

        [HttpGet("holiday/calendars")]
        public IActionResult Calendars()
        {
            if (ModelState.IsValid)
            {
                var result = _holidayCalendarRegistry.Keys;
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("holiday/{calendar}/is-holiday/{date}")]
        public IActionResult IsHoliday(HolidayCalendarDateParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.Calendar, out var calendar))
                {
                    return NotFound(param.Calendar);
                }
                var result = calendar.IsHoliday(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("holiday/{calendar}/not-holiday/{date}")]
        public IActionResult IsNotHoliday(HolidayCalendarDateParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.Calendar, out var calendar))
                {
                    return NotFound(param.Calendar);
                }
                var result = calendar.IsNotHoliday(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("holiday/{calendar}/next-holiday/{date}")]
        public IActionResult NextHoliday(HolidayCalendarNextPrevDateParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.Calendar, out var calendar))
                {
                    return NotFound(param.Calendar);
                }
                var result = calendar.NextHoliday(param.Date, param.IncludeDate);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("holiday/{calendar}/next-nonHoliday/{date}")]
        public IActionResult NextNonHoliday(HolidayCalendarNextPrevDateParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.Calendar, out var calendar))
                {
                    return NotFound(param.Calendar);
                }
                var result = calendar.NextNonHoliday(param.Date, param.IncludeDate);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("holiday/{calendar}/prev-holiday/{date}")]
        public IActionResult PreviousHoliday(HolidayCalendarNextPrevDateParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.Calendar, out var calendar))
                {
                    return NotFound(param.Calendar);
                }
                var result = calendar.PreviousHoliday(param.Date, param.IncludeDate);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("holiday/{calendar}/prev-non-holiday/{date}")]
        public IActionResult PreviousNonHoliday(HolidayCalendarNextPrevDateParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.Calendar, out var calendar))
                {
                    return NotFound(param.Calendar);
                }
                var result = calendar.PreviousNonHoliday(param.Date, param.IncludeDate);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("day-adjust/conventions")]
        public IActionResult DayAdjustmentConventions()
        {
            if (ModelState.IsValid)
            {
                var result = _dayAdjustmentConventionRegistry.Keys;
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("day-adjust/{dayAdjustConvention}/adjust/{calendar}/{date}")]
        public IActionResult DayAdjustment(AdjustDayParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_holidayCalendarRegistry.TryGetValue(param.Calendar, out var calendar))
                {
                    return NotFound(nameof(param.Calendar));
                }
                if (!_dayAdjustmentConventionRegistry.TryGetValue(param.DayAdjustConvention, out var convention))
                {
                    return NotFound(nameof(param.DayAdjustConvention));
                }
                var result = convention.Adjust(param.Date, calendar);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("day-count/conventions")]
        public IActionResult DayCountConventions()
        {
            if (ModelState.IsValid)
            {
                var result = _dayCountConventionRegistry.Keys;
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("day-count/{dayCountConvention}/year-fraction/{startDate}/{endDate}")]
        public IActionResult YearFraction(YearFractionParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_dayCountConventionRegistry.TryGetValue(param.DayCountConvention, out var convention))
                {
                    return NotFound(nameof(param.DayCountConvention));
                }
                var result = convention.YearFraction(param.StartDate, param.EndDate);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("day-roll/conventions")]
        public IActionResult RollConventions()
        {
            if (ModelState.IsValid)
            {
                var result = _dayRollConventionRegistry.Keys;
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("day-roll/{dayRollConvention}/is-eom")]
        public IActionResult IsEndOfMonth(DayRollConventionParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_dayRollConventionRegistry.TryGetValue(param.DayRollConvention, out var convention))
                {
                    return NotFound(nameof(param.DayRollConvention));
                }
                var result = convention.IsEOM;
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("day-roll/{dayCountConvention}/is-roll/{date}")]
        public IActionResult IsRollDate(DayRollDateParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_dayRollConventionRegistry.TryGetValue(param.DayRollConvention, out var convention))
                {
                    return NotFound(nameof(param.DayRollConvention));
                }
                var result = convention.IsRollDate(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("day-roll/{dayCountConvention}/roll/{date}")]
        public IActionResult RollDate(DayRollDateParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_dayRollConventionRegistry.TryGetValue(param.DayRollConvention, out var convention))
                {
                    return NotFound(nameof(param.DayRollConvention));
                }
                var result = convention.Roll(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("day-roll/{dayCountConvention}/next-roll/{date}")]
        public IActionResult NextRoll(DayRollDateParam param)
        {
            if (ModelState.IsValid)
            {
                if (!_dayRollConventionRegistry.TryGetValue(param.DayRollConvention, out var convention))
                {
                    return NotFound(nameof(param.DayRollConvention));
                }
                var result = convention.NextRoll(param.Date);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
