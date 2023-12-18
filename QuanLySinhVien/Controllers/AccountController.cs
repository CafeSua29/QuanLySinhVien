using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using QuanLySinhVien.Models;
using QuanLySinhVien.App_Start;
using System.Web.UI.WebControls;
using QuanLySinhVien.Models.ViewModel;

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
                var tvSession = db.TaiKhoans.Where(m => m.UserName.Equals(UserName)).FirstOrDefault();
                if (tvSession != null && tvSession.Password.Equals(Password))
                {
                    Session["username"] = tvSession.UserName;
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
            Session.Remove("username");

            return RedirectToAction("Login");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ThanhVienAuthorize(MaChucNang = "TKSV")]
        public ActionResult ChangePassword(ChangePasswordModel ChPass)
        {
            if (ModelState.IsValid)
            {
                string UserName = (string)Session["username"];
                var tk = db.TaiKhoans.FirstOrDefault(m => m.UserName == UserName);
                if (tk.Password.Equals(ChPass.CurrentPassword))
                {
                    tk.Password = ChPass.NewPassword;
                    db.SaveChanges();
                    return RedirectToAction("Logout", "Account");
                }
                else
                {
                    TempData["Error"] = "Sai mật khẩu";
                    return View();
                }
            }
            else 
            {
                return View(); 
            }
        }
    }
}