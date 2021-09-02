using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;


namespace eShop.ApplicationService.Services
{
    public class OrderApplicationService : IOrderApplicationService
    {
        private IOrderRepository _OrderRepository;
        public OrderApplicationService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public List<OrderQueryDTO> GetOrders()
        {
            return _OrderRepository.GetOrders();
        }
        public List<InsideCartDTO> GetCartInfo(string userMail)
        {

            return _OrderRepository.GetCartInfo(userMail);
        }
        public bool AddToCart(AddOrderDTO addOrderDTO)
        {
            OrderEntity OrderModel = new OrderEntity();
            OrderModel.Set(addOrderDTO);

            return _OrderRepository.AddToCart(OrderModel, addOrderDTO.ProductId, addOrderDTO.Quantity);
        }

        public void DeleteProductFromCart(string userMail, Guid productId)
        {
             _OrderRepository.DeleteProductFromCart(userMail, productId);

        }

        public void Payment(string userMail, Guid addressId)
        {
            _OrderRepository.Payment(userMail, addressId);
        }
    }
}
