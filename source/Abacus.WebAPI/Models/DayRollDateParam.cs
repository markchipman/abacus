using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{

    public class DayRollDateParam : DayRollConventionParam
    {
        [Required]
        [FromRoute(Name = "date")]
        public DateTime Date { get; set; }
    }
}
