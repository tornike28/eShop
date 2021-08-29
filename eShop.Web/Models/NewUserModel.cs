using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class NewUserModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        [Compare("PasswordHash", ErrorMessage = "პაროლი არ ემთხვევა")]
        public string PasswordHashRepeat { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Role { get; set; }
    }
}
