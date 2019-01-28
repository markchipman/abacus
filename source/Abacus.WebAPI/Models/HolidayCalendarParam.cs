using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class HolidayCalendarParam
    {
        [Required]
        [FromRoute(Name = "calendar")]
        public string Calendar { get; set; }
    }
}
