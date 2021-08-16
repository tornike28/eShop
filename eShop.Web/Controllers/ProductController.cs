using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductApplicationService _ProductApplicationService;
        public ProductController(IProductApplicationService ProductApplicationService)
        {
            _ProductApplicationService = ProductApplicationService;
        }

        public IActionResult ProductDetails(Guid ProductID)
        {
            var result = _ProductApplicationService.GetProduct(ProductID);
            return View(result);
        }
    }
}
