using System;

namespace eShop.Admin.Models
{
    public class LoginModel
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
