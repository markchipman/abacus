using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{

    public class HolidayCalendarDateParam : HolidayCalendarParam
    {
        [Required]
        [FromRoute]
        public DateTime Date { get; set; }
    }
}
