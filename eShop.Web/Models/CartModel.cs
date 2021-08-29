using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class CartModel
    {
        public Guid ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public Guid? UserAddressID { get; set; }
        public int Quantity { get; set; }
    }
}
