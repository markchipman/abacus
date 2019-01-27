using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{

    public class YearFractionParam : DayCountConventionParam
    {
        [Required]
        [FromRoute]
        public DateTime StartDate { get; set; }

        [Required]
        [FromRoute]
        public DateTime EndDate { get; set; }
    }
}
