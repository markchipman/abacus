using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class HolidayCalendarNextPrevDateParam : HolidayCalendarDateParam
    {
        [FromQuery(Name = "includeDate")]
        public bool IncludeDate { get; set; } = false;
    }
}
