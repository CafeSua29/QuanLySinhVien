using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.Models;
using System.Text.RegularExpressions;
using System.Globalization;
using OfficeOpenXml;
using System.Data.Entity.Migrations;
using System.Runtime.Remoting.Messaging;


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
            ViewBag.MaKhoa = new SelectList(KhoaBUS.DanhSachKhoa(), "MaKhoa", "TenKhoa");
            ViewBag.MaLop = new SelectList(new List<Lop>(), "MaLop", "TenLop");
            return View(new SinhVien());
        }

        [HttpPost]
        public ActionResult ThemSinhVien(string MaKhoa, SinhVien sv)
        {
            if (ModelState.IsValid)
            {
                QuanLySinhVienEntities db = new QuanLySinhVienEntities();
                var check = db.SinhViens.FirstOrDefault(m => m.MaSV == sv.MaSV);

                if(check != null)
                {
                    ViewBag.MaKhoa = new SelectList(KhoaBUS.DanhSachKhoa(), "MaKhoa", "TenKhoa", MaKhoa);
                    ViewBag.MaLop = new SelectList(LopBUS.DanhSachLopTheoKhoa(MaKhoa), "MaLop", "TenLop", sv.MaLop);
                    TempData["Error5"] = "Mã sinh viên không được trùng";
                    return View(sv);
                }
                else 
                {
                    db.SinhViens.Add(sv);
                    db.SaveChanges(); 
                    return RedirectToAction("DanhSachSinhVien");
                }
            }
            else 
            {
                ViewBag.MaKhoa = new SelectList(KhoaBUS.DanhSachKhoa(), "MaKhoa", "TenKhoa", MaKhoa);
                ViewBag.MaLop = new SelectList(LopBUS.DanhSachLopTheoKhoa(MaKhoa), "MaLop", "TenLop", sv.MaLop);
                TempData["Error6"] = "Không thể thêm mới sinh viên";
                return View(sv); 
            }
        }

        public ActionResult SuaSinhVien(string masv)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            SinhVien sv = db.SinhViens.Find(masv);
            string MaKhoa = LopBUS.LopTheoSinhVien(sv.MaLop).MaKhoa;
            ViewBag.MaKhoa = new SelectList(KhoaBUS.DanhSachKhoa(), "MaKhoa", "TenKhoa", MaKhoa);
            ViewBag.MaLop = new SelectList(LopBUS.DanhSachLopTheoKhoa(MaKhoa), "MaLop", "TenLop", sv.MaLop);
            return View(sv);
        }

        [HttpPost]
        public ActionResult SuaSinhVien(SinhVien sv, string MaKhoa)
        {
            if (ModelState.IsValid)
            {
                QuanLySinhVienEntities db = new QuanLySinhVienEntities();

                db.SinhViens.AddOrUpdate(sv);
                db.SaveChanges();

                return RedirectToAction("DanhSachSinhVien");
            }
            else 
            {
                ViewBag.MaKhoa = new SelectList(KhoaBUS.DanhSachKhoa(), "MaKhoa", "TenKhoa", MaKhoa);
                ViewBag.MaLop = new SelectList(LopBUS.DanhSachLopTheoKhoa(MaKhoa), "MaLop", "TenLop", sv.MaLop);
                TempData["Error5"] = "Không thể sửa thông tin sinh viên";
                return View(sv);
            }
        }

        [HttpPost]
        public JsonResult DanhSachLopTheoKhoa(string id)
        {
            var dsLop = (from item in LopBUS.DanhSachLopTheoKhoa(id)
                        select new
                        {
                            MaLop = item.MaLop,
                            TenLop = item.TenLop,
                            MaKhoa = item.MaKhoa,
                        }).ToList();
            return Json(new { dsLop = dsLop }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult XoaSinhVien(string masv)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            SinhVien sv = db.SinhViens.Find(masv);

            db.SinhViens.Remove(sv);
            db.SaveChanges();

            return RedirectToAction("DanhSachSinhVien");
        }

        public void XuatFileExcel()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            List<SinhVien> listSV = db.SinhViens.ToList();

            ExcelPackage ep = new ExcelPackage();
            ExcelWorksheet Sheet = ep.Workbook.Worksheets.Add("Report");

            Sheet.Cells["A1"].Value = "Mã sinh viên";
            Sheet.Cells["B1"].Value = "Họ sinh viên";
            Sheet.Cells["C1"].Value = "Tên sinh viên";
            Sheet.Cells["D1"].Value = "Giới tính";
            Sheet.Cells["E1"].Value = "Ngày sinh";
            Sheet.Cells["F1"].Value = "Quê quán";
            Sheet.Cells["G1"].Value = "Số điện thoại";
            Sheet.Cells["H1"].Value = "Lớp";

            int row = 2;

            foreach (var sv in listSV)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = sv.MaSV;
                Sheet.Cells[string.Format("B{0}", row)].Value = sv.HoSV;
                Sheet.Cells[string.Format("C{0}", row)].Value = sv.TenSV;
                Sheet.Cells[string.Format("D{0}", row)].Value = sv.GioiTinh;
                Sheet.Cells[string.Format("E{0}", row)].Value = sv.NgaySinh.ToString("dd-MM-yyyy");
                Sheet.Cells[string.Format("F{0}", row)].Value = sv.QueQuan;
                Sheet.Cells[string.Format("G{0}", row)].Value = sv.SoDienThoai;
                Sheet.Cells[string.Format("H{0}", row)].Value = sv.MaLop;
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + "Report.xlsx");
            Response.BinaryWrite(ep.GetAsByteArray());
            Response.End();
        }

        [HttpPost]
        public ActionResult TimSinhVien(String masv)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            SinhVien sv = db.SinhViens.Find(masv);

            return View(sv);
        }
    }
}