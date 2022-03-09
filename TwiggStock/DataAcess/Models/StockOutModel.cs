using System;
using System.Text.Json.Serialization;

namespace TwiggStock.DataAcess.Models
{
    public class StockOutModel
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public Guid Categorie_Id { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public Guid Author_id { get; set; }
        public DateTime Created_on { get; set; }
    }
}
