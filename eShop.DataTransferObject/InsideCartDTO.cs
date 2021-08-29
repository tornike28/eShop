using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class InsideCartDTO
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid ProductId { get;  set; }
        public decimal price { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
       
    }
}
