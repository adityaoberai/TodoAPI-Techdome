using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class User
    {
        [JsonPropertyName("fname")]
        public string FirstName { get; set; } = "";
        [JsonPropertyName("lname")]
        public string LastName { get; set; } = "";
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = false;
        [JsonPropertyName("role")]
        public string Role { get; set; } = "User";
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
    }
}
