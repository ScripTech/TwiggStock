using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TwiggStock.Models
{
    public class DepartmentBugdet
    {
        [Required(ErrorMessage="Department is required.")]
        public Guid Department_id { get; set; }

        [Required(ErrorMessage="Budget Value is required.")]
        public float Budget_value { get; set; }
        public float Budget_used { get; set; } = 0;
        public int Budget_year { get; set; } = DateTime.Now.Year;

        [Required(ErrorMessage="User uuid for event action log is required.")]
        public Guid Author_id { get; set; }
    }
}
