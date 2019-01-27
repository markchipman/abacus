using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{

    public class AdjustDayParam : DayAdjustConventionParam
    {
        [Required]
        [FromRoute]
        public string Calendar { get; set; }

        [Required]
        [FromRoute]
        public DateTime Date { get; set; }
    }
}
