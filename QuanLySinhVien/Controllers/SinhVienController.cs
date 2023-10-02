using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        QuanLySinhVienEntities db = new QuanLySinhVienEntities();
        // GET: SinhVien
        public ActionResult DanhSachSinhVien()
        {
            return View();
        }

        public ActionResult ChiTietSinhVien()
        {
            return View();
        }
        public ActionResult ThemSinhVien()
        {
            ViewBag.MaLop = new SelectList(LopBUS.DanhSachLop(),"MaLop", "TenLop");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSinhVien(SinhVien model)
        {
            if(ModelState.IsValid)
            {
                var check = db.SinhViens.FirstOrDefault(x => x.MaSV == model.MaSV);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SinhViens.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("DanhSachSinhVien");
                }
                else
                {
                    ViewBag.MaLop = new SelectList(LopBUS.DanhSachLop(), "MaLop", "TenLop");
                    TempData["Error"] = "Mã sinh viên đã tồn tại";
                    return View(model);
                }
            }
            else
            {
                ViewBag.MaLop = new SelectList(LopBUS.DanhSachLop(), "MaLop", "TenLop");
                return View(model);
            }
        }
    }
}