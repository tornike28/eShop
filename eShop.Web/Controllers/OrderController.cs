using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Controllers
{
    public class OrderController : Controller
    {
        IProductApplicationService _ProductApplicationService;

        public OrderController(IProductApplicationService ProductApplicationService)
        {
            _ProductApplicationService = ProductApplicationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(Guid ProductId)
        {
            _ProductApplicationService.AddToCart(ProductId);
            return RedirectToAction(controllerName:"Home",actionName:"Index");
        }
        public IActionResult InsideCart()
        {
            //var viewModel = _ProductApplicationService.GetCartInfo();


            return View(/*viewModel*/);
        }
    }
}
