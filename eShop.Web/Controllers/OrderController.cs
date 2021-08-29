using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.Web.Models;
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

        public IActionResult AddToCart(CartModel cartModel)
        {
           
            Guid UserId = Guid.NewGuid();
          
            _OrderApplicationService.AddToCart(new AddOrderDTO() 
            {
                ProductId = cartModel.ProductId,
                TotalPrice = cartModel.ProductPrice,
                UserAddressID =cartModel.UserAddressID,
                UserID = UserId,
                Quantity = cartModel.Quantity
            });
            return RedirectToAction(controllerName:"Home",actionName:"Index");
        }
        public IActionResult InsideCart()
        {
            //სესიიდან წამოვიღებ
            Guid UserId = Guid.NewGuid();
            var viewModel = _OrderApplicationService.GetCartInfo(UserId);


            return View(/*viewModel*/);
        }
    }
}
