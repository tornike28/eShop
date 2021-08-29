using eShop.ApplicationService.ServiceInterfaces;
using eShop.Web.Models;
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
            Guid UserId = Guid.NewGuid();
            var listofShoppingCarts = _OrderApplicationService.GetCartInfo(UserId).ToList();
            var numberofrecords = listofShoppingCarts.Count();

            var viewModel = new ShoppingCart
            {
                NumberOfRecords = numberofrecords
            };

            return View(viewModel);
        }
    }

}