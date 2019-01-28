using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class DayRollConventionParam
    {
        [Required]
        [FromRoute(Name = "dayRollConvention")]
        public string DayRollConvention { get; set; }
    }
}
