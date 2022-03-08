using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TwiggStock.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }
        public string Mail_notification { get; set; }

        #nullable disable
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required]
        #nullable disable
        public bool Must_change_passwd { get; set; } = true;

        #nullable enable
        public DateTime? Email_verified_at { get; set; }

        #nullable disable
        public string Last_login_on { get; set; }

        public string Language { get; set; }

        public DateTime Created_on { get; set; }

        public DateTime Updated_on { get; set; }

        #nullable enable
        public DateTime? Deleted_on { get; set; }
    }
}
