using eShop.Admin.Attributes;
using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult GetCategories(int categoryID)
        {
            var query = _CategoryApplicationService.GetCategories(categoryID);
            return View(query);
        }

        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(string CategoryName)
        {
            var query = _CategoryApplicationService.AddCategory(new DataTransferObject.CategoryDTO() { CategoryName = CategoryName });
            return View(query);
        }
        [HttpPost]
        public IActionResult DeleteCategory(int CategoryID)
        {
            _CategoryApplicationService.DeleteCategory(CategoryID);
            return RedirectToAction(controllerName: "Category", actionName: "GetCategories");
        }

    }
}
