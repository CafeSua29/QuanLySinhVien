using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QuanLySinhVien.Models;
using QuanLySinhVien.Models.BUS;

namespace QuanLySinhVien.App_Start
{
    public class ThanhVienAuthorize : AuthorizeAttribute
    {
        public string MaChucNang { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string tkSession = (string)HttpContext.Current.Session["user"];
            if (tkSession != null)
            {
                QuanLySinhVienEntities db = new QuanLySinhVienEntities();
                string MaVT = ThanhVienBUS.ChiTietThanhVien(tkSession).MaVT;
                var count = db.PhanQuyens.Count(m => m.MaVT == MaVT && m.MaCN == MaChucNang);
                if(count != 0 || MaChucNang == "KCQ")
                {
                    return;
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(
                    new
                    {
                        controller = "BaoLoi",
                        action = "KhongCoQuyen",
                        area = ""
                    }));
                }
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