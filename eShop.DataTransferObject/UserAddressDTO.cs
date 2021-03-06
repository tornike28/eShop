using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class UserAddressDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public string City { get; set; }

        public string FullAddress { get; set; }

        public bool IsPrimary { get; set; }
    }
}
