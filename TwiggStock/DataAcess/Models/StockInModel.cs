using System;
using System.Text.Json.Serialization;

namespace TwiggStock.DataAcess.Models
{
    public class StockInModel
    {
        public int Id { get; set; }
        public System.Guid Uuid { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Guid Supplier_Id { get; set; }
        public Guid Categorie_Id { get; set; }
        public double Value { get; set; }
        public DateTime Spent_date { get; set; }
        public string Spent_category { get; set; }
        public Guid Author_id { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime Updated_on { get; set; }

        #nullable enable
        public string Item_Model { get; set; } = "";

        #nullable enable
        public DateTime? Deleted_on { get; set; }
    }
}
