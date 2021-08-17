using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    public class OrderController : Controller
    {
        private IOrderApplicationService _OrderApplicationService;
        public OrderController(IOrderApplicationService OrderApplicationService)
        {
            _OrderApplicationService = OrderApplicationService;
        }
        public IActionResult Index()
        {
            _OrderApplicationService.GetOrders();
            return View();
        }
    }
}
