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

            var userAddress = _UserApplicationService.GetUserAddresses(UserMail);

            var viewModel = new GetUserModel()
            {
                User = user,
                UserAddress = userAddress
            };

            return View(viewModel);
        }
        public IActionResult UpdateUserInformation(UpdateUserInfoModel updateUserInfoModel)
        {

            _UserApplicationService.UpdateUserInformation(new UserDTO()
            {
                FirstName = updateUserInfoModel.FirstName,
                LastName = updateUserInfoModel.LastName,
                Email = updateUserInfoModel.Email
            });

            return RedirectToAction(controllerName: "User", actionName: "GetUser");
        }
        public IActionResult SaveUserAddress(UserAddressModel userAddressModel)
        {
            var UserMail = HttpContext.Session.GetString("UserName");

            _UserApplicationService.SaveUserAddress(new UserAddressDTO()
            {
                City = userAddressModel.City,
                FullAddress = userAddressModel.FullAddress,
                Email = UserMail,
                IsPrimary = userAddressModel.IsPrimary

            });

            return RedirectToAction(controllerName: "User", actionName: "GetUser");
        }

    }
}
