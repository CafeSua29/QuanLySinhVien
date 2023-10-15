using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                var check = db.TaiKhoans.FirstOrDefault(m => m.UserName.Equals(model.UserName));
                if (check == null)
                {
                    db.TaiKhoans.Add(new TaiKhoan
                    {
                        UserName = model.UserName,
                        Password = model.Password
                    });
                    db.ThanhViens.Add(new ThanhVien
                    {
                        UserName = model.UserName
                    });
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Error"] = "Tên đăng nhập đã được sử dụng";
                    return View(model);
                }
            }
            return View(model);
        }
    }
}