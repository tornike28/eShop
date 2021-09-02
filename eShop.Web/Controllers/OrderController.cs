using eShop.Admin.Attributes;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Controllers
{
    public class OrderController : Controller
    {
        IOrderApplicationService _OrderApplicationService;

        public OrderController(IOrderApplicationService OrderApplicationService)
        {
            _OrderApplicationService = OrderApplicationService;
        }
        [Authorize]
        public IActionResult AddToCart(CartModel cartModel)
        {
            if (cartModel.Quantity == 0)
            {
                cartModel.Quantity = 1;
            }
            var UserMail = HttpContext.Session.GetString("UserName");

            _OrderApplicationService.AddToCart(new AddOrderDTO()
            {
                ProductId = cartModel.ProductId,
                TotalPrice = cartModel.ProductPrice,
                UserAddressID = cartModel.UserAddressID,
                UserMail = UserMail,
                Quantity = cartModel.Quantity
            });
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }

        [Authorize]
        public IActionResult InsideCart()
        {
            var UserMail = HttpContext.Session.GetString("UserName");

            var viewModel = _OrderApplicationService.GetCartInfo(UserMail);
            ViewBag.TotalPrice = viewModel.Select(x => x.TotalPrice).FirstOrDefault(); 

            return View(viewModel);
        }
    }
}
