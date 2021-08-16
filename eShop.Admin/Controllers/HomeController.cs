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
using Newtonsoft.Json;
using System.Web;
using static eShop.Admin.Models.DataPoint;

namespace eShop.Admin.Controllers
{
    public class HomeController : Controller
    {
        IUserApplicationService  _UserApplicationService;
        public HomeController(IUserApplicationService UserApplicationService)
        {
            _UserApplicationService = UserApplicationService;
        }

        [Route("")]
        [Authorize]
        public IActionResult Index()
        {
            List<DataPoint> DataPoints = new List<DataPoint>();
           var products = _UserApplicationService.GetUsersStatisticQuery();
         
            foreach (var item in products)
            {
                var dataPoint = new DataPoint(item.Month, item.NumberOfUsers);
                DataPoints.Add(dataPoint);
            }
       

            ViewBag.DataPoints = JsonConvert.SerializeObject(DataPoints);
            return View(DataPoints);
        }

        [Authorize]
        public IActionResult Test()
        {
            return View();
        }
    }
}
