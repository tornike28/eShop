using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class InsideCartModel
    {
        public List<InsideCartDTO> CartInfo { get; set; }

        public List<UserAddressDTO> address { get; set; }
    }
}
