using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TwiggStock.Models
{
    public class StockOut
    {
        public int Id { get; set; }
        public System.Guid Uuid { get; set; }

        [Required(ErrorMessage = "StockOut Categorie ID is required")]
        public System.Guid Categorie_Id { get; set; }
        public string Model { get; set; }
        [Required(ErrorMessage = "StockOut Quantity is required")]
        public int Quantity { get; set; }
        public System.Guid Author_id { get; set; }
        public DateTime Created_on { get; set; }
    }
}
