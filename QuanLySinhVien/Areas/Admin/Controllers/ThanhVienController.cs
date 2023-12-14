using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.Models;
using QuanLySinhVien.Models.BUS;
using QuanLySinhVien.App_Start;

namespace QuanLySinhVien.Areas.Admin.Controllers
{
    [AdminAuthorite]
    public class ThanhVienController : Controller
    {
        // GET: Admin/Home
        QuanLySinhVienEntities db = new QuanLySinhVienEntities();

        public ActionResult DanhSachThanhVien()
        {
            return View(ThanhVienBUS.DanhSachThanhVien());
        }

        public ActionResult ThemTaiKhoan()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemTaiKhoan(TaiKhoan model)
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
                        UserName = model.UserName,
                        HoTV = "",
                        TenTV = "",
                        GioiTinh = "Không xác định",
                        NgaySinh = DateTime.Now,
                        QueQuan = "",
                        SoDienThoai = 0,
                        MaVT = "KhongCoVaiTro",
                    });
                    db.SaveChanges();
                    return RedirectToAction("CapNhatThanhVien", "ThanhVien", new {UserName = model.UserName});
                }
                else
                {
                    TempData["Error"] = "Tên đăng nhập đã được sử dụng";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult CapNhatThanhVien(string UserName)
        {
            ViewBag.MaVT = new SelectList(VaiTroBUS.DanhSachVaiTro(), "MaVT", "TenVT", ThanhVienBUS.ChiTietThanhVien(UserName).MaVT);
            return View(ThanhVienBUS.ChiTietThanhVien(UserName));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhatThanhVien(ThanhVien tv, string MaVT)
        {
            if (ModelState.IsValid)
            {
                db.ThanhViens.AddOrUpdate(tv);
                db.SaveChanges();
                return RedirectToAction("DanhSachThanhVien");
            }
            else
            {
                ViewBag.MaVT = new SelectList(VaiTroBUS.DanhSachVaiTro(), "MaVT", "TenVT", MaVT);
                TempData["Error"] = "Không thể sửa thông tin sinh viên";
                return View(tv);
            }
        }

        public ActionResult XoaThanhVien(string UserName)
        {
            TaiKhoan tk =  db.TaiKhoans.Find(UserName);
            db.TaiKhoans.Remove(tk);
            db.SaveChanges();
            return RedirectToAction("DanhSachThanhVien");
        }

        public ActionResult ChiTietThanhVien(string UserName)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            ThanhVien tv = db.ThanhViens.Find(UserName);
            return View(tv);
        }
    }
}