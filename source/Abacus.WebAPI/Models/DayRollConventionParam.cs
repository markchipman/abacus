using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class DayRollConventionParam
    {
        [Required]
        [FromRoute]
        public string DayRollConvention { get; set; }
    }
}
