using eShop.ApplicationService.ServiceInterfaces;
using eShop.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private IOrderApplicationService _OrderApplicationService;
        public ShoppingCartViewComponent(IOrderApplicationService OrderApplicationService)
        {
            _OrderApplicationService = OrderApplicationService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var UserMail = HttpContext.Session.GetString("UserName");

            var listofShoppingCarts = _OrderApplicationService.GetCartInfo(UserMail).ToList();
            var numberofrecords = listofShoppingCarts.Count();

            var viewModel = new ShoppingCart
            {
                NumberOfRecords = numberofrecords
            };

            return View(viewModel);
        }
    }

}