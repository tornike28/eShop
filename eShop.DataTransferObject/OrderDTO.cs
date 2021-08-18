using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
   public class OrderQueryDTO
    {
        public Guid OrderID { get; set; }
        public string OrderStatus { get; set; }
        public string UserMail { get; set; }
        public string UserAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
