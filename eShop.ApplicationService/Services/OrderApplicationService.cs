using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
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
    }
}
