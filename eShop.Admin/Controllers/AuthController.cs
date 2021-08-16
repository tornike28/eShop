using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        IUserApplicationService _UserApplicationService;
        public AuthController(IUserApplicationService UserApplicationService)
        {
            _UserApplicationService = UserApplicationService;
        }
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }


        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginModel Login)
        {
            var responseCore = _UserApplicationService.Login(new LoginDTO()
            {
                Email = Login.Email,
                PasswordHash = Login.PasswordHash
            });

            if (responseCore.Messages.Count == 0)
            {
                HttpContext.Session.SetString("SessionID", responseCore.SessionID.ToString());
                HttpContext.Session.SetString("UserName", Login.Email);

                return RedirectToAction(actionName:"Index",controllerName:"Home");
            }
            else
            {
                return View(responseCore.Messages);
            }
        }

        public IActionResult LogOut()
        {
            string sessionId = Guid.Parse(HttpContext.Session.GetString("SessionID")).ToString();
            string userName = Guid.Parse(HttpContext.Session.GetString("UserName")).ToString(); ;

            HttpContext.Session.Remove(sessionId);
            HttpContext.Session.Remove(userName);

            return RedirectToAction(controllerName:"Auth",actionName:"Login");
        }

    }
}
