using System;
using System.Text.Json.Serialization;

namespace TwiggStock.DataAcess.Models
{
    public class DepartmentsModel
    {
        public int Id { get; set; }
        public System.Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Slug_Name { get; set; }
        public string Group_Email { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime Updated_on { get; set; }
        #nullable enable
        public DateTime? Deleted_on { get; set; }
    }
}
