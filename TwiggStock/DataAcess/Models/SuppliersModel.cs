using System;
using System.Text.Json.Serialization;

namespace TwiggStock.DataAcess.Models
{
    public class SuppliersModel
    {
        public int Id { get; set; }
        public System.Guid Uuid { get; set; }
        public string Name { get; set; }
        public int Nuit { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Cell_Number { get; set; }
        public string Email_Address { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime Updated_on { get; set; }
        #nullable enable
        public DateTime? Deleted_on { get; set; }
    }
}
