using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySinhVien.Areas.Admin.Controllers
{
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