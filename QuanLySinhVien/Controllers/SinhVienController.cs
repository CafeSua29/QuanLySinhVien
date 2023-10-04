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
        // GET: SinhVien
        public ActionResult DanhSachSinhVien()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            List<SinhVien> listSV = db.SinhViens.ToList();

            return View(listSV);
        }

        public ActionResult ChiTietSinhVien(String masv)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            SinhVien sv = db.SinhViens.Find(masv);

            return View(sv);
        }

        public ActionResult ThemSinhVien()
        {
            return View(new SinhVien());
        }

        [HttpPost]
        public ActionResult ThemSinhVien(SinhVien sv)
        {
            if(string.IsNullOrEmpty(sv.MaSV))
            {
                ModelState.AddModelError("", "Ma sinh vien khong duoc de trong");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.HoSV))
            {
                ModelState.AddModelError("", "Ho sinh vien khong duoc de trong");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.TenSV))
            {
                ModelState.AddModelError("", "Ten sinh vien khong duoc de trong");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.GioiTinh))
            {
                ModelState.AddModelError("", "Gioi tinh khong duoc de trong");
                return View(sv);
            }

            if (sv.NgaySinh == DateTime.MinValue)
            {
                ModelState.AddModelError("", "Ngay sinh chua duoc chon");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.QueQuan))
            {
                ModelState.AddModelError("", "Que quan khong duoc de trong");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.SoDienThoai))
            {
                ModelState.AddModelError("", "So dien thoai sinh vien khong duoc de trong");
                return View(sv);
            }

            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            db.SinhViens.Add(sv);
            db.SaveChanges();

            return RedirectToAction("DanhSachSinhVien");
        }

        public ActionResult SuaSinhVien(string masv)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            SinhVien sv = db.SinhViens.Find(masv);

            return View(sv);
        }

        [HttpPost]
        public ActionResult SuaSinhVien(SinhVien sv)
        {
            if (string.IsNullOrEmpty(sv.MaSV))
            {
                ModelState.AddModelError("", "Ma sinh vien khong duoc de trong");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.HoSV))
            {
                ModelState.AddModelError("", "Ho sinh vien khong duoc de trong");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.TenSV))
            {
                ModelState.AddModelError("", "Ten sinh vien khong duoc de trong");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.GioiTinh))
            {
                ModelState.AddModelError("", "Gioi tinh khong duoc de trong");
                return View(sv);
            }

            if (sv.NgaySinh == DateTime.MinValue)
            {
                ModelState.AddModelError("", "Ngay sinh chua duoc chon");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.QueQuan))
            {
                ModelState.AddModelError("", "Que quan khong duoc de trong");
                return View(sv);
            }

            if (string.IsNullOrEmpty(sv.SoDienThoai))
            {
                ModelState.AddModelError("", "So dien thoai sinh vien khong duoc de trong");
                return View(sv);
            }

            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            var suasv = db.SinhViens.Find(sv.MaSV);

            suasv.MaSV = sv.MaSV;
            suasv.HoSV = sv.HoSV;
            suasv.TenSV = sv.TenSV;
            suasv.GioiTinh = sv.GioiTinh;
            suasv.NgaySinh = sv.NgaySinh;
            suasv.QueQuan = sv.QueQuan;
            suasv.SoDienThoai = sv.SoDienThoai;
            suasv.MaLop = sv.MaLop;

            db.SaveChanges();

            return RedirectToAction("DanhSachSinhVien");
        }

        public ActionResult XoaSinhVien(string masv)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            SinhVien sv = db.SinhViens.Find(masv);

            db.SinhViens.Remove(sv);
            db.SaveChanges();

            return RedirectToAction("DanhSachSinhVien");
        }
    }
}