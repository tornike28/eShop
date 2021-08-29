﻿using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IOrderApplicationService
    {
        public List<OrderQueryDTO> GetOrders();
        bool AddToCart(AddOrderDTO addOrderDTO);
        List<InsideCartDTO> GetCartInfo(Guid userID);

    }
}
