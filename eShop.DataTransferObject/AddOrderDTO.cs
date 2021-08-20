using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class AddOrderDTO
    {
        public Guid ProductID { get; set; }
        public Guid UserID { get; set; }
        public decimal ProductPrice { get; set; }
        public Guid UserAddressID { get; set; }
    }
}
