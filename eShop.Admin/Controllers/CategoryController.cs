using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {

        ICategoryApplicationService _CategoryApplicationService;
        public CategoryController(ICategoryApplicationService CategoryApplicationService)
        {
            _CategoryApplicationService = CategoryApplicationService;
        }

        public IActionResult GetCategories(int? categoryID =null)
        {
            var query = _CategoryApplicationService.GetCategories(categoryID);
            return View(query);
        }


        [HttpGet]
        public string GetCategory(int id)
        {
            var query = _CategoryApplicationService.GetCategories(id).First();
            return JsonSerializer.Serialize(query);
        }
        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryModel Category)
        {
            var query = _CategoryApplicationService.AddCategory(new DataTransferObject.CategoryDTO() { CategoryName = Category.CategoryName });
            return View(query);
        }
        [HttpPost]
        public IActionResult DeleteCategory(CategoryModel Category)
        {
            _CategoryApplicationService.DeleteCategory(Category.CategoryID);
            return RedirectToAction(controllerName: "Category", actionName: "GetCategories");
        }

        public IActionResult SaveCategory(CategoryModel categoryModel)
        {
            _CategoryApplicationService.SaveCategory(new CategoryDTO() { CategoryName = categoryModel.CategoryName,Id = categoryModel.CategoryID });

            return RedirectToAction(controllerName: "Category", actionName: "GetCategories");
        }

    }
}
