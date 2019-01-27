using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class DayCountConventionParam
    {
        [Required]
        [FromRoute]
        public string DayCountConvention { get; set; }
    }
}
