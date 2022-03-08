using System;
using System.Text.Json.Serialization;

namespace TwiggStock.DataAcess.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public System.Guid Uuid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }

        [JsonIgnore]
        #nullable disable
        public string Password { get; set; }

        [JsonIgnore]
        #nullable disable
        public bool Must_change_passwd { get; set; } = true;

        [JsonIgnore]
        public DateTime? Passwd_changed_on { get; set; }

        #nullable disable
        public string Mail_notification { get; set; }

        public DateTime? Email_verified_at { get; set; }

        #nullable enable
        public string? Last_login_on { get; set; } = null;

        #nullable enable
        public string? Language { get; set; } = "PT-pt";

        [JsonIgnore]
        #nullable disable
        public string Salt { get; set; }

        public DateTime Created_on { get; set; }

        public DateTime Updated_on { get; set; }

        #nullable enable
        public DateTime? Deleted_on { get; set; }
    }

}
