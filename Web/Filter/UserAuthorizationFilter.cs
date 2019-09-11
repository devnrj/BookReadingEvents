using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Filters
{
    public class UserAuthorizationFilter : AuthorizeAttribute
    {
      
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;            
            var User = (UserViewModel)httpContext.Session["UserData"];                 
            if (User.IsAdmin == true)
            {               
                authorize = true;
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {            
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}