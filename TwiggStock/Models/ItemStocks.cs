using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace TwiggStock.Models
{
    public class ItemStocks
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Stock In Items Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Stock In Items Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Stock In Items Supplier must be specified")]
        public Guid Supplier_Id { get; set; }

        [Required(ErrorMessage = "Stock In Items Categorie must be specified")]
        public Guid Categorie_Id { get; set; }

        [Range(minimum:1, maximum:99999999, ErrorMessage = "Stock value must be between 1 and")]
        public double Value { get; set; }
        public string Item_Model { get; set; }
        public System.Guid Author_id { get; set; }
        public DateTime spent_date { get; set; }

        #nullable enable
        public string? spent_category { get; set; }
    }
}
