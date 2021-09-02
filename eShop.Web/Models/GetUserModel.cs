using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class GetUserModel
    {
        public UserQueryDTO User { get; set; }
        public List<UserAddressDTO> UserAddress { get; set; }
    }
}
