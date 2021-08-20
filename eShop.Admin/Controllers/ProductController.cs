using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        IProductApplicationService _ProductApplicationService;
        ICategoryApplicationService _CategoryApplicationService;
        public ProductController(IProductApplicationService ProductApplicationService, ICategoryApplicationService CategoryApplicationService)
        {
            _ProductApplicationService = ProductApplicationService;
            _CategoryApplicationService = CategoryApplicationService;
        }

        [Authorize]
        public IActionResult GetProduct()
        {
            var query = _ProductApplicationService.AdminGetProduct();


            return View(query);
        }
        public string GetProductInfo(string id)
        {
            Guid productId = Guid.Parse(id);
            var product = _ProductApplicationService.AdminGetProduct(productId);
            return JsonSerializer.Serialize(product);
        }
        public IActionResult AddProduct()
        {
            ViewBag.categories = _CategoryApplicationService.GetCategories().Where(x => x.Status == Status.Active).ToList();
            ViewBag.Units = _ProductApplicationService.GetUnits().ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductModel productModel)
        {
           var filenames =  await _ProductApplicationService.UploadImages(productModel.ImageFiles);

            //Insert record

            var query = _ProductApplicationService.AddProduct(new ProductDTO()
            { 
                CategoryIds = productModel.CategoryID,
                Name = productModel.ProductName,
                Description = productModel.Description,
                Price = productModel.Price,
                Quantity = productModel.Quantity,
                UnitID = productModel.UnitID
            }, filenames);
            if (query.IsError)
            {
                return Content($"{query.ErrorMessages.First()}");
            }
            else
            {
                return RedirectToAction(controllerName: "Product", actionName: "GetProduct");
            }

        }

        [HttpPost]
        public IActionResult DeleteProduct(Guid ProductID)
        {
            _ProductApplicationService.DeleteProduct(ProductID);
            return RedirectToAction(controllerName: "Product", actionName: "GetProduct");
        }
    }
}
