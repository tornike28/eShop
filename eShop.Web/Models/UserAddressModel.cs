using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class UserAddressModel
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string FullAddress { get; set; }
    }
}
