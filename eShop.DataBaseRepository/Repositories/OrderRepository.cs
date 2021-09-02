using eShop.DataBaseRepository.DB;
using eShop.DataBaseRepository.DB.Models;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace eShop.DataBaseRepository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public bool AddToCart(OrderEntity orderEntity, Guid productID, int quantity)
        {
            using (var scope = new TransactionScope())
            {
                using (eShopDBContext context = new eShopDBContext())
                {
                    try
                    {
                        var UserId = (from u in context.Users
                                      where u.Email == orderEntity.UserMail
                                      select u.Id).FirstOrDefault();

                        var order = context.Orders.Where(x => x.UserId == UserId && x.OrderStatusId == 0).FirstOrDefault();

                        if (order is null)
                        {
                            Order newOrder = new Order()
                            {
                                Id = orderEntity.Id,
                                TotalPrice = orderEntity.TotalPrice,
                                UserId = UserId,
                                UserAddressId = orderEntity.UserAddressID,
                                OrderStatusId = 0,
                                DateCreated = orderEntity.DateCreated
                            };
                            OrderDetail orderDetail = new OrderDetail()
                            {
                                Id = Guid.NewGuid(),
                                ProductId = productID,
                                Price = orderEntity.TotalPrice,
                                Quantity = quantity,
                                DateCreated = orderEntity.DateCreated,
                                OrderId = orderEntity.Id,

                            };
                            context.Orders.Add(newOrder);
                            context.OrderDetails.Add(orderDetail);
                            context.SaveChanges();
                        }
                        else
                        {
                            order.TotalPrice += orderEntity.TotalPrice;

                            OrderDetail orderDetail = new OrderDetail()
                            {
                                Id = Guid.NewGuid(),
                                ProductId = productID,
                                Price = orderEntity.TotalPrice,
                                Quantity = quantity,
                                DateCreated = orderEntity.DateCreated,
                                OrderId = order.Id,
                            };
                            context.OrderDetails.Add(orderDetail);

                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        return false;
                    }
                    finally
                    {
                        scope.Complete();
                    }
                    return true;

                }
            }
        }

        public List<InsideCartDTO> GetCartInfo(string userMail)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from od in context.OrderDetails
                             join o in context.Orders on od.OrderId equals o.Id
                             join os in context.OrderStatuses on o.OrderStatusId equals os.Id
                             join p in context.Products on od.ProductId equals p.Id
                             join u in context.Users on o.UserId equals u.Id
                             where u.Email == userMail && o.OrderStatusId == 0

                             select new InsideCartDTO
                             {
                                 CreateDate = o.DateCreated,
                                 Id = o.Id,
                                 TotalPrice = o.TotalPrice,
                                 ProductId = od.ProductId,
                                 ProductName = p.Name,
                                 price = od.Price,
                                 Quantity = od.Quantity
                             }).ToList();

                return query;
            }
        }

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
