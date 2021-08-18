using eShop.DataBaseRepository.DB;
using eShop.DataTransferObject;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<OrderQueryDTO> GetOrders()
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from o in context.Orders
                             join u in context.Users on o.UserId equals u.Id
                             join ua in context.UserAddresses on o.UserAddressId equals ua.Id
                             join os in context.OrderStatuses on o.OrderStatusId equals os.Id
                             select new OrderQueryDTO
                             {
                                OrderID = o.Id,
                                UserMail = u.Email,
                                UserAddress = ua.FullAddress,
                                OrderStatus = os.Name,
                                TotalPrice = o.TotalPrice,
                                DateCreated = o.DateCreated
                             }).ToList();

                return query;
            }
        }
    }
}
