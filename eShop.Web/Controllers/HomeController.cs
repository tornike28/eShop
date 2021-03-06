using eShop.ApplicationService.ServiceInterfaces;
using eShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductApplicationService _ProductApplicationService;
        public HomeController(IProductApplicationService ProductApplicationService)
        {
            _ProductApplicationService = ProductApplicationService;
        }

        public IActionResult Index(int page = 1)
        {
            var products = _ProductApplicationService.GetProduct(page);
            ViewBag.PreviousPage = page - 1;
            ViewBag.NextPage = page + 1;

            return View(products);
       }

        public IActionResult About()
        {
            return View();
        }


    }
}
