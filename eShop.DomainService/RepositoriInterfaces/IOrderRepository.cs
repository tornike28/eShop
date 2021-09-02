using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IOrderRepository
    {
        List<OrderQueryDTO> GetOrders();
        bool AddToCart(OrderEntity orderEntity, Guid productID, int quantity);
        List<InsideCartDTO> GetCartInfo(string userMail);
    }
}
