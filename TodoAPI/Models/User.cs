using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class User
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsActive { get; set; } = false;
        public string Role { get; set; } = "User";
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; } = "";
    }
}
