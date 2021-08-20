using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        IUserApplicationService _UserApplicationService;
        public UserController(IUserApplicationService UserApplicationService)
        {
            _UserApplicationService = UserApplicationService;
        }

        public IActionResult GetUsers()
        {
            var query = _UserApplicationService.GetUsersQuery();
            return View(query);
        }

        public IActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegistration(NewUserModel newUserModel)
        {
            var query = _UserApplicationService.UserRegistraion(new UserDTO()
            {
                Email = newUserModel.Email,
                FirstName = newUserModel.FirstName,
                LastName = newUserModel.LastName,
                PasswordHash = newUserModel.PasswordHash,
                PasswordHashRepeat = newUserModel.PasswordHashRepeat,
            });

            return View(query);
        }

        [HttpPost]
        public IActionResult DeleteUser(Guid UserID)
        {
            _UserApplicationService.DeleteUser(UserID);
            return RedirectToAction(controllerName: "User", actionName: "GetUsers");
        }
    }
}
