using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainModel.Entity
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public Guid? UserAddressID { get; set; }
        public Guid UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }

        public void Set(AddOrderDTO order)
        {
            Id = Guid.NewGuid();
            UserAddressID = order.UserAddressID;
            UserID = order.UserID;
            TotalPrice = order.TotalPrice;
            DateCreated = DateTime.Now;
        }
    }
}
