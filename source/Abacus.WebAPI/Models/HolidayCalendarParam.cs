using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class HolidayCalendarParam
    {
        [Required]
        [FromRoute]
        public string Calendar { get; set; }
    }
}
