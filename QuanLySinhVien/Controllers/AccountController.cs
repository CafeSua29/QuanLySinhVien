using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Controllers
{
    public class AccountController : Controller
    {
        QuanLySinhVienEntities db = new QuanLySinhVienEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var tvSession = db.TaiKhoans.SingleOrDefault(m => m.UserName.ToLower().Equals(UserName.ToLower()) && m.Password.Equals(Password));
                if (tvSession != null)
                {
                    Session["user"] = tvSession.UserName;
                    if (tvSession.UserName == "admin")
                    {
                        return RedirectToAction("DanhSachThanhVien", "ThanhVien", new { area = "Admin" });
                    }
                    return RedirectToAction("DanhSachSinhVien", "SinhVien");
                }
                else
                {
                    TempData["Error"] = "Tài khoản hoặc mật khẩu không đúng";
                    ViewBag.UserName = UserName;
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("user");

            return RedirectToAction("Login");
        }
    }
}