using eShop.Admin.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Attributes
{
    public class LoginAttribute :TypeFilterAttribute
    {
        public LoginAttribute() :base(typeof(LoginActionFilter))
        {
            Arguments = new object[] { };
        }
    }
}
