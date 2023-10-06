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
            //if(string.IsNullOrEmpty(sv.MaSV))
            //{
            //    ModelState.AddModelError("", "Ma sinh vien khong duoc de trong");
            //    return View(sv);
            //}

            //if (string.IsNullOrEmpty(sv.HoSV))
            //{
            //    ModelState.AddModelError("", "Ho sinh vien khong duoc de trong");
            //    return View(sv);
            //}

            //bool chekho = Regex.IsMatch(sv.HoSV, @"^[a-zA-Z]+$");

            //if (!chekho)
            //{
            //    ModelState.AddModelError("", "Ho cua sinh vien khong hop le");
            //    return View(sv);
            //}

            //if (string.IsNullOrEmpty(sv.TenSV))
            //{
            //    ModelState.AddModelError("", "Ten sinh vien khong duoc de trong");
            //    return View(sv);
            //}

            //bool chekten = Regex.IsMatch(sv.TenSV, @"^[a-zA-Z]+$");

            //if (!chekten)
            //{
            //    ModelState.AddModelError("", "Ten cua sinh vien khong hop le");
            //    return View(sv);
            //}



            //if (sv.NgaySinh == DateTime.MinValue)
            //{
            //    ModelState.AddModelError("", "Ngay sinh chua duoc chon");
            //    return View(sv);
            //}

            //int tuoi = DateTime.Now.Year - sv.NgaySinh.Year;



            //if (string.IsNullOrEmpty(sv.QueQuan))
            //{
            //    ModelState.AddModelError("", "Que quan khong duoc de trong");
            //    return View(sv);
            //}

            //bool chekque = Regex.IsMatch(sv.QueQuan, @"^[a-zA-Z]+$");

            //if (!chekque)
            //{
            //    ModelState.AddModelError("", "Que quan cua sinh vien khong hop le");
            //    return View(sv);
            //}

            //if (string.IsNullOrEmpty(sv.SoDienThoai))
            //{
            //    ModelState.AddModelError("", "So dien thoai sinh vien khong duoc de trong");
            //    return View(sv);
            //}

            //bool cheksdt = Regex.IsMatch(sv.SoDienThoai, @"^(\+84|0)[0-9]{7,10}$");

            //if (!cheksdt)
            //{
            //    ModelState.AddModelError("", "So dien thoai khong hop le");
            //    return View(sv);
            //}
            if (ModelState.IsValid)
            {
                int tuoi = DateTime.Now.Year - sv.NgaySinh.Year;
                if (tuoi < 18)
                {
                    TempData["Error"] = "Ngày tháng năm sinh không hợp lệ";
                    //ModelState.AddModelError("", "Ngay thang nam sinh khong hop le");
                    return View(sv);
                }
                QuanLySinhVienEntities db = new QuanLySinhVienEntities();
                List<SinhVien> listSV = db.SinhViens.ToList();
                var check = db.SinhViens.FirstOrDefault(m => m.MaSV == sv.MaSV);
                if(check != null)
                {
                    TempData["Error2"] = "Mã sinh viên không được trùng";
                    //ModelState.AddModelError("", "Ma sinh vien khong duoc trung");
                    return View(sv);
                }
                else {db.SinhViens.Add(sv);
                db.SaveChanges(); }
                return RedirectToAction("DanhSachSinhVien");
                //foreach(var svien in listSV)
                //{
                //    if (svien.MaSV.Equals(sv.MaSV))
                //    {

                //    }
                //}
            }
            else { return View(sv); }

            
        }

        public ActionResult SuaSinhVien(string masv)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            SinhVien sv = db.SinhViens.Find(masv);
            ViewBag.NgaySinh = sv.NgaySinh;
            return View(sv);
        }

        [HttpPost]
        public ActionResult SuaSinhVien(SinhVien sv)
        {
            //if (string.IsNullOrEmpty(sv.MaSV))
            //{
            //    ModelState.AddModelError("", "Ma sinh vien khong duoc de trong");
            //    return View(sv);
            //}

            //if (string.IsNullOrEmpty(sv.HoSV))
            //{
            //    ModelState.AddModelError("", "Ho sinh vien khong duoc de trong");
            //    return View(sv);
            //}

            //bool chekho = Regex.IsMatch(sv.HoSV, @"^[a-zA-Z]+$");

            //if (!chekho)
            //{
            //    ModelState.AddModelError("", "Ho cua sinh vien khong hop le");
            //    return View(sv);
            //}

            //if (string.IsNullOrEmpty(sv.TenSV))
            //{
            //    ModelState.AddModelError("", "Ten sinh vien khong duoc de trong");
            //    return View(sv);
            //}

            //bool chekten = Regex.IsMatch(sv.TenSV, @"^[a-zA-Z]+$");

            //if (!chekten)
            //{
            //    ModelState.AddModelError("", "Ten cua sinh vien khong hop le");
            //    return View(sv);
            //}

            //if (string.IsNullOrEmpty(sv.GioiTinh))
            //{
            //    ModelState.AddModelError("", "Gioi tinh khong duoc de trong");
            //    return View(sv);
            //}

            //if (sv.NgaySinh == DateTime.MinValue)
            //{
            //    ModelState.AddModelError("", "Ngay sinh chua duoc chon");
            //    return View(sv);
            //}

            //int tuoi = DateTime.Now.Year - sv.NgaySinh.Year;

            //if (tuoi < 18)
            //{
            //    ModelState.AddModelError("", "Ngay thang nam sinh khong hop le");
            //    return View(sv);
            //}

            //if (string.IsNullOrEmpty(sv.QueQuan))
            //{
            //    ModelState.AddModelError("", "Que quan khong duoc de trong");
            //    return View(sv);
            //}

            //bool chekque = Regex.IsMatch(sv.QueQuan, @"^[a-zA-Z]+$");

            //if (!chekque)
            //{
            //    ModelState.AddModelError("", "Que quan cua sinh vien khong hop le");
            //    return View(sv);
            //}

            //if (string.IsNullOrEmpty(sv.SoDienThoai))
            //{
            //    ModelState.AddModelError("", "So dien thoai sinh vien khong duoc de trong");
            //    return View(sv);
            //}

            //bool cheksdt = Regex.IsMatch(sv.SoDienThoai, @"^(\+84|0)[0-9]{7,10}$");

            //if (!cheksdt)
            //{
            //    ModelState.AddModelError("", "So dien thoai khong hop le");
            //    return View(sv);
            //}

            if (ModelState.IsValid)
            {
                int tuoi = DateTime.Now.Year - sv.NgaySinh.Year;
                if (tuoi < 18)
                {
                    TempData["Error"] = "Ngày tháng năm sinh không hợp lệ";
                    //ModelState.AddModelError("", "Ngay thang nam sinh khong hop le");
                    return View(sv);
                }
                QuanLySinhVienEntities db = new QuanLySinhVienEntities();
                var suasv = db.SinhViens.Find(sv.MaSV);

                //suasv.MaSV = sv.MaSV;
                //suasv.HoSV = sv.HoSV;
                //suasv.TenSV = sv.TenSV;
                //suasv.GioiTinh = sv.GioiTinh;
                //suasv.NgaySinh = sv.NgaySinh;
                //suasv.QueQuan = sv.QueQuan;
                //suasv.SoDienThoai = sv.SoDienThoai;
                //suasv.MaLop = sv.MaLop;
                db.SinhViens.AddOrUpdate(sv);
                db.SaveChanges();

                return RedirectToAction("DanhSachSinhVien");
            }
            else { return View(sv); }
            
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

            Sheet.Cells["A1"].Value = "Ma sinh vien";
            Sheet.Cells["B1"].Value = "Ho sinh vien";
            Sheet.Cells["C1"].Value = "Ten sinh vien";
            Sheet.Cells["D1"].Value = "Gioi tinh";
            Sheet.Cells["E1"].Value = "Ngay sinh";
            Sheet.Cells["F1"].Value = "Que quan";
            Sheet.Cells["G1"].Value = "So dien thoai";
            Sheet.Cells["H1"].Value = "Lop quan ly";

            int row = 2;// dòng bắt đầu ghi dữ liệu
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
    }
}