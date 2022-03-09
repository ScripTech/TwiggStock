using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace TwiggStock.Models
{
    public class Suppliers
    {
        [Required(ErrorMessage="Department name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage="Department Nuit is required.")]
        public int Nuit { get; set; }
        [Required(ErrorMessage="Department Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage="Department City is required.")]
        public string City { get; set; }
        public string Address { get; set; }
        public string Cell_Number { get; set; }
        public string Email_Address { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
