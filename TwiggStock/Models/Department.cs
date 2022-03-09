using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TwiggStock.Models
{
    public class Department
    {
        [Required(ErrorMessage="Department name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage="Department Sigla is required.")]
        public string Slug_Name { get; set; }

        [Required(ErrorMessage="Department Nuit is required.")]
        public string Group_Email { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
