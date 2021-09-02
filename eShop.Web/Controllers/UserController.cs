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
    public class UserController : Controller
    {

        private IUserApplicationService _UserApplicationService;

        public UserController(IUserApplicationService UserApplicationService)
        {
            _UserApplicationService = UserApplicationService;
        }
        public IActionResult GetUser()
        {
            var UserMail = HttpContext.Session.GetString("UserName");

            var user = _UserApplicationService.GetUserQuery(UserMail);

            return View(user);
        }
        public IActionResult UpdateUserInformation(UpdateUserInfoModel updateUserInfoModel)
        {

            _UserApplicationService.UpdateUserInformation(new UserDTO()
            {
                FirstName = updateUserInfoModel.FirstName,
                LastName = updateUserInfoModel.LastName,
                Email = updateUserInfoModel.Email
            });

            return RedirectToAction(controllerName: "User", actionName:"GetUser");
        }
    }
}
