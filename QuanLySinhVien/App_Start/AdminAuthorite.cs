using QuanLySinhVien.Models.BUS;
using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLySinhVien.App_Start
{
    public class AdminAuthorite : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string tkSession = (string)HttpContext.Current.Session["username"];
            if (tkSession != null && tkSession == "admin")
            {
                return;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(
                    new
                    {
                        controller = "Account",
                        action = "login",
                        area = ""
                    }));
            }
        }
    }
}