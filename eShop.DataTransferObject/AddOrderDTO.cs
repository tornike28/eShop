using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class AddOrderDTO
    {
        public Guid ProductId { get; set; }
        public string UserMail { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid? UserAddressID { get; set; }
        public int Quantity { get; set; }
    }
}
