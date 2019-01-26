using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebApi.Models
{
    public class DayAdjustmentParam
    {
        [FromRoute]
        [Required]
        public string ConventionId { get; set; }

        [FromRoute]
        [Required]
        public DateTime Date { get; set; }

        [FromRoute]
        public string CalendarId { get; set; } = "none";
    }
}
