using eShop.ApplicationService.ServiceInterfaces;
using eShop.Web.Models;
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

        public IActionResult ProductDetails(Guid ProductID,string CategoryName)
        {
            var products = _ProductApplicationService.AdminGetProduct(ProductID).First();
            var relatedProducts = _ProductApplicationService.RelatedProductsQuery(CategoryName);
            var result = new ProductDetailsModel
            {
                ProductDetailInfo = products,
                RelatedProductsInfo = relatedProducts
            };
            return View(result);
        }
    }
}
