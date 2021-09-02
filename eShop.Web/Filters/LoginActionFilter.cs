using eShop.DomainService.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Filters
{
    public class LoginActionFilter : IAuthorizationFilter
    {
        IUserDomainService _auth;
        Guid _sessionID;
        public LoginActionFilter(IUserDomainService auth)
        {
            _auth = auth;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                _sessionID = Guid.Parse(context.HttpContext.Session.GetString("SessionID"));
                bool isAuthorized = _auth.CheckSessionIsValid(_sessionID);
                if (!isAuthorized)
                {
                    context.Result = new RedirectResult("~/Auth/Register/");
                }

            }
            catch (Exception ex)
            {
                context.Result = new RedirectResult("~/auth/Register/");
            }
        }
    }
}
