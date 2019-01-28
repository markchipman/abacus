using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class DayAdjustConventionParam
    {
        [Required]
        [FromRoute(Name = "dayAjustConvention")]
        public string DayAdjustConvention { get; set; }
    }
}
