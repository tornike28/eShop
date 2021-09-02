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
        IUserApplicationService _UserApplicationService;

        public OrderController(IOrderApplicationService OrderApplicationService, IUserApplicationService UserApplicationService)
        {
            _OrderApplicationService = OrderApplicationService;
            _UserApplicationService = UserApplicationService;
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

            var cartInfo = _OrderApplicationService.GetCartInfo(UserMail);
            ViewBag.TotalPrice = cartInfo.Select(x => x.TotalPrice).FirstOrDefault();

            var userAddress = _UserApplicationService.GetUserAddresses(UserMail);

            var viewModel = new InsideCartModel()
            {
                address = userAddress,
                CartInfo = cartInfo
            };

            return View(viewModel);
        }
    }
}
