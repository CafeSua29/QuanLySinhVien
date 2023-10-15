using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLySinhVien.App_Start
{
    public class ThanhVienAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            string tkSession = (string)HttpContext.Current.Session["user"];
            if (tkSession != null)
            {
                return;
            }
            else
            {
                //var returnUrl = filterContext.RequestContext.HttpContext.Request.Url;
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(
                    new
                    {
                        controller = "Account",
                        action = "login",
                        area = "",
                        //returnUrl = returnUrl.ToString(),
                    }));
            }
        }
    }
}