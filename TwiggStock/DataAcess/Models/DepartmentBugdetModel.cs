using System;
using System.Text.Json.Serialization;

namespace TwiggStock.DataAcess.Models
{
    public class DepartmentBugdetModel
    {
        public int Id { get; set; }
        public Guid Department_id { get; set; }
        public float Budget_value { get; set; }
        public float Budget_used { get; set; }
        public int Budget_year { get; set; }
        public Guid Author_id { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime Updated_on { get; set; }
        #nullable enable
        public DateTime? Deleted_on { get; set; }
        public DepartmentsModel? departments { get; }
        public string? Name { get; set; }
        public string? Slug_Name { get; set; }
    }
}
