using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TwiggStock.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public System.Guid Uuid { get; set; }

        [Required(ErrorMessage = "Categorie Categories is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "StockIn Supplier must be specified")]
        public Guid Supplier_Id { get; set; }
        public System.Guid Author_id { get; set; }
    }
}
