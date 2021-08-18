using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        IProductApplicationService _ProductApplicationService;
        public ProductController(IProductApplicationService ProductApplicationService)
        {
            _ProductApplicationService = ProductApplicationService;
        }

        [Authorize]
        public IActionResult GetProduct()
        {
            var query = _ProductApplicationService.GetProduct(null, null);


            return View(query);
        }

        public IActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductModel productModel)
        {
            List<string> fileNames = new List<string>();

            foreach (var file in productModel.ImageFiles)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\Upload\\");
                bool basePathExists = Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                fileName = $"{ Guid.NewGuid()}{ extension}";
                var filePath = Path.Combine(basePath, fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    fileNames.Add(filePath);
                }
            }

            //Insert record

            var query = _ProductApplicationService.AddProduct(new ProductDTO()
            {
                CategoryId = productModel.CategoryID,
                Name = productModel.ProductName,
                Description = productModel.Description,
                Price = productModel.Price,
                Quantity = productModel.Quantity,
                UnitID = productModel.UnitID
            }, fileNames);
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
