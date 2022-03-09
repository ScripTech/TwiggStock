using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TwiggStock.DataAcess.Models
{
    public class CategoriesModel
    {
        public int Id { get; set; }
        public System.Guid Uuid { get; set; }
        public string Description { get; set; }
        public Guid Supplier_Id { get; set; }
        public System.Guid Author_id { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime Updated_on { get; set; }
        #nullable enable
        public DateTime? Deleted_on { get; set; }
    }
}
