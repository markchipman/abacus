using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{

    public class YearFractionParam : DayCountConventionParam
    {
        [Required]
        [FromRoute(Name = "startDate")]
        public DateTime StartDate { get; set; }

        [Required]
        [FromRoute(Name = "endDate")]
        public DateTime EndDate { get; set; }
    }
}
