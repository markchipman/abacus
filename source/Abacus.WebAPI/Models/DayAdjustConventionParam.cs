using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class DayAdjustConventionParam
    {
        [Required]
        [FromRoute]
        public string DayAdjustConvention { get; set; }
    }
}
