using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Controllers
{
    public class AuthController : Controller
    {
        private IUserApplicationService _UserApplicationService;

        public AuthController(IUserApplicationService UserApplicationService)
        {
            _UserApplicationService = UserApplicationService;
        }

        public IActionResult Login(LoginModel loginModel)
        {
            var responseCore = _UserApplicationService.Login(new LoginDTO() { Email = loginModel.Email, PasswordHash = loginModel.Password });

            if (responseCore.Messages.Count == 0)
            {
                HttpContext.Session.SetString("SessionID", responseCore.SessionID.ToString());
                HttpContext.Session.SetString("UserName", loginModel.Email);

                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            else
            {
                return View(responseCore.Messages);
            }
        }


        public IActionResult LogOut()
        {
            var sessionId = Guid.Parse(HttpContext.Session.GetString("SessionID"));

            HttpContext.Session.Remove("SessionID");
            HttpContext.Session.Remove("UserName");
            _UserApplicationService.DeleteSessionID(sessionId);
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }

        public IActionResult Authorization()
        {
            return View();
        }

        public IActionResult Verify(ResultDTO result)
        {
            return View(result);
        }

        [HttpPost]
        public IActionResult Verify()
        {
            string userMail = "";
            _UserApplicationService.UserActivation(userMail);
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Register(NewUserModel UserModel)
        {
            if (ModelState.IsValid)
            {
                var result = _UserApplicationService.UserRegistration(new UserDTO()
                {
                    Email = UserModel.Email,
                    FirstName = UserModel.FirstName,
                    LastName = UserModel.LastName,
                    PasswordHash = UserModel.PasswordHash,
                    PasswordHashRepeat = UserModel.PasswordHashRepeat,
                });
                if (result.IsError)
                {
                    return View(result);
                }
                else
                {
                    return RedirectToAction(controllerName: "Auth", actionName: "Verify", routeValues: result);
                }

            }
            return View();
        }

    }
}
