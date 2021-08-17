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
                var query = (from c in context.Orders
                             select new CategoryDTO
                             {
                                 Id = c.Id,
                                 CategoryName = c.Name,
                                 DateCreated = c.DateCreated,
                                 Status = c.DateDeleted != null ? Status.Deleted : Status.Active
                             }).ToList();

                return query;
            }
        }
    }
}
