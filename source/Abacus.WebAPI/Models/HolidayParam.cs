using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class HolidayParam
    {
        [FromRoute]
        [Required]
        public string CalendarId { get; set; }

        [FromRoute]
        [Required]
        public DateTime Date { get; set; }
    }
}
