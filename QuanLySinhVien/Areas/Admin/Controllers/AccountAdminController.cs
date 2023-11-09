using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.App_Start;

namespace QuanLySinhVien.Areas.Admin.Controllers
{
    [AdminAuthorite]
    public class AccountAdminController : Controller
    {
        // GET: Admin/AccountAdmin
        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction("Login", "Account", new { area = "" });
        }
    }
}