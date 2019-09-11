using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Web.Models;

namespace Web.Helper
{
    public class AuthorizeSelfAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }

            var rd = httpContext.Request.RequestContext.RouteData;

            var id = rd.Values["id"];
            String userName = httpContext.User.Identity.Name;

           // Submission submission = unit.SubmissionRepository.GetByID(id);
            UserViewModel user = Mapper.ToUserViewModel(UserService.GetUserByUsername(userName));

            return 2 == user.UserID;
        }
    }
}