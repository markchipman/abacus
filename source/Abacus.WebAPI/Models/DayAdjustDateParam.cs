using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{

    public class AdjustDayParam : DayAdjustConventionParam
    {
        [Required]
        [FromRoute(Name = "calendar")]
        public string Calendar { get; set; }

        [Required]
        [FromRoute(Name = "date")]
        public DateTime Date { get; set; }
    }
}
