using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [Route("")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Test()
        {
            return View();
        }
    }
}
