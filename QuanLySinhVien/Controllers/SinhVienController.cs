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
using QuanLySinhVien.App_Start;
using QuanLySinhVien.Models.BUS;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace QuanLySinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        [ThanhVienAuthorize(MaChucNang = "DSSV")]
        public ActionResult DanhSachSinhVien()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            List<SinhVien> listSV = db.SinhViens.ToList();
            return View(listSV);
        }

        [ThanhVienAuthorize(MaChucNang = "CTSV")]
        public ActionResult ChiTietSinhVien(String masv)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            SinhVien sv = db.SinhViens.Find(masv);

            return View(sv);
        }

        [ThanhVienAuthorize(MaChucNang = "TSV")]
        public ActionResult ThemSinhVien()
        {
            ViewBag.MaKhoa = new SelectList(KhoaBUS.DanhSachKhoa(), "MaKhoa", "TenKhoa");
            ViewBag.MaLop = new SelectList(new List<Lop>(), "MaLop", "TenLop");
            return View(new SinhVien());
        }

        [HttpPost]
        [ThanhVienAuthorize(MaChucNang = "TSV")]
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

        [ThanhVienAuthorize(MaChucNang = "SSV")]
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
        [ThanhVienAuthorize(MaChucNang = "SSV")]
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

        [ThanhVienAuthorize(MaChucNang = "XSV")]
        public ActionResult XoaSinhVien(string masv)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            SinhVien sv = db.SinhViens.Find(masv);

            db.SinhViens.Remove(sv);
            db.SaveChanges();
            return RedirectToAction("DanhSachSinhVien");
        }

        //[HttpPost]
        //public async Task<List<SinhVien>> NhapFileExcel(IFormFile file)
        //{
        //    QuanLySinhVienEntities db = new QuanLySinhVienEntities();
        //    List<SinhVien> list = new List<SinhVien>();

        //    using (var stream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(stream);

        //        using (var package = new ExcelPackage(stream))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //            var rowcount = worksheet.Dimension.Rows;

        //            for (int row = 2; row <= rowcount; row++)
        //            {
        //                var malop = "";
        //                var lops = db.Lops.ToList();

        //                foreach (var lop in lops)
        //                {
        //                    if (lop.TenLop == worksheet.Cells[row, 8].Value.ToString().Trim())
        //                    {
        //                        malop = lop.MaLop;
        //                    }
        //                }

        //                list.Add(new SinhVien
        //                {
        //                    MaSV = worksheet.Cells[row, 1].Value.ToString().Trim(),
        //                    HoSV = worksheet.Cells[row, 2].Value.ToString().Trim(),
        //                    TenSV = worksheet.Cells[row, 3].Value.ToString().Trim(),
        //                    GioiTinh = worksheet.Cells[row, 4].Value.ToString().Trim(),
        //                    NgaySinh = DateTime.ParseExact(worksheet.Cells[row, 5].Value.ToString().Trim(), "yyyy-MM-dd", null),
        //                    QueQuan = worksheet.Cells[row, 6].Value.ToString().Trim(),
        //                    SoDienThoai = worksheet.Cells[row, 7].Value.ToString().Trim(),
        //                    MaLop = malop,
        //                    DiemTBHK = float.Parse(worksheet.Cells[row, 9].Value.ToString().Trim())
        //                });
        //            }
        //        }
        //    }

        //    return list;
        //}

        //[HttpPost]
        //public ActionResult NhapFileExcel()
        //{
        //    QuanLySinhVienEntities db = new QuanLySinhVienEntities();
        //    List<SinhVien> list = new List<SinhVien>();

        //    if (Request != null)
        //    {
        //        HttpPostedFileBase file = Request.Files["file"];
        //        if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
        //        {
        //            byte[] fileBytes = new byte[file.ContentLength];
        //            var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
        //            using (var package = new ExcelPackage(file.InputStream))
        //            {
        //                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //                var currentSheet = package.Workbook.Worksheets;
        //                var workSheet = currentSheet.First();
        //                var noOfCol = workSheet.Dimension.End.Column;
        //                var noOfRow = workSheet.Dimension.End.Row;

        //                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
        //                {
        //                    var malop = "";
        //                    var lops = db.Lops.ToList();

        //                    foreach (var lop in lops)
        //                    {
        //                        if (lop.TenLop == workSheet.Cells[rowIterator, 8].Value.ToString().Trim())
        //                        {
        //                            malop = lop.MaLop;
        //                        }
        //                    }

        //                    list.Add(new SinhVien
        //                    {
        //                        MaSV = workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
        //                        HoSV = workSheet.Cells[rowIterator, 2].Value.ToString().Trim(),
        //                        TenSV = workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
        //                        GioiTinh = workSheet.Cells[rowIterator, 4].Value.ToString().Trim(),
        //                        NgaySinh = DateTime.ParseExact(workSheet.Cells[rowIterator, 5].Value.ToString().Trim(), "dd-MM-yyyy", null),
        //                        QueQuan = workSheet.Cells[rowIterator, 6].Value.ToString().Trim(),
        //                        SoDienThoai = workSheet.Cells[rowIterator, 7].Value.ToString().Trim(),
        //                        MaLop = malop,
        //                        //DiemTBHK = float.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim())
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    foreach(SinhVien sv in list)
        //    {
        //        db.SinhViens.Add(sv);
        //        db.SaveChanges();
        //    }

        //    return RedirectToAction("DanhSachSinhVien");
        //}

        [HttpPost]
        public ActionResult NhapFileExcel()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();

            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["file"];

                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var malop = "";
                            var lops = db.Lops.ToList();

                            foreach (var lop in lops)
                            {
                                if (lop.TenLop == worksheet.Cells[row, 8].Value.ToString().Trim())
                                {
                                    malop = lop.MaLop;
                                }
                            }

                            SinhVien sv = new SinhVien
                            {
                                MaSV = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                HoSV = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                TenSV = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                GioiTinh = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                NgaySinh = DateTime.ParseExact(worksheet.Cells[row, 5].Value.ToString().Trim(), "dd-MM-yyyy", null),
                                QueQuan = worksheet.Cells[row, 6].Value.ToString().Trim(),
                                SoDienThoai = worksheet.Cells[row, 7].Value.ToString().Trim(),
                                MaLop = malop,
                                DiemTBHK = (worksheet.Cells[row, 9].Value == null ? -1 : float.Parse(worksheet.Cells[row, 9].Value.ToString().Trim()))
                            };

                            db.SinhViens.Add(sv);
                            db.SaveChanges();

                            //if(worksheet.Cells[row, 9].Value == null)
                            //{
                            //    SinhVien sv = new SinhVien
                            //    {
                            //        MaSV = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            //        HoSV = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            //        TenSV = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            //        GioiTinh = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            //        NgaySinh = DateTime.ParseExact(worksheet.Cells[row, 5].Value.ToString().Trim(), "dd-MM-yyyy", null),
                            //        QueQuan = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            //        SoDienThoai = worksheet.Cells[row, 7].Value.ToString().Trim(),
                            //        MaLop = malop,
                            //        DiemTBHK = (worksheet.Cells[row, 9].Value == null ? -1 : float.Parse(worksheet.Cells[row, 9].Value.ToString().Trim()))
                            //    };

                            //    db.SinhViens.Add(sv);
                            //    db.SaveChanges();
                            //}
                            //else
                            //{
                            //    SinhVien sv = new SinhVien
                            //    {
                            //        MaSV = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            //        HoSV = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            //        TenSV = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            //        GioiTinh = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            //        NgaySinh = DateTime.ParseExact(worksheet.Cells[row, 5].Value.ToString().Trim(), "dd-MM-yyyy", null),
                            //        QueQuan = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            //        SoDienThoai = worksheet.Cells[row, 7].Value.ToString().Trim(),
                            //        MaLop = malop,
                            //        DiemTBHK = float.Parse(worksheet.Cells[row, 9].Value.ToString().Trim())
                            //    };

                            //    db.SinhViens.Add(sv);
                            //    db.SaveChanges();
                            //}
                        }
                    }
                }
            }

            return RedirectToAction("DanhSachSinhVien");
        }

        [ThanhVienAuthorize(MaChucNang = "XFE")]
        public void XuatFileExcel(string MaKhoa, string MaLop)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();

            List<SinhVien> listSV;

            if (MaLop == null || MaLop == "" || MaLop == "--Chọn lớp--")
            {
                if(MaKhoa == null || MaKhoa == "" || MaKhoa == "--Chọn khoa--")
                {
                    listSV = db.SinhViens.ToList();
                }
                else
                {
                    listSV = (from sv in db.SinhViens
                              join lop in db.Lops
                              on sv.MaLop equals lop.MaLop
                              join khoa in db.Khoas
                              on lop.MaKhoa equals khoa.MaKhoa
                              where khoa.MaKhoa == MaKhoa
                              select sv
                              ).ToList();
                }
            }
            else
            {
                listSV = db.SinhViens.Where(i => i.MaLop == MaLop).ToList();
            }

            ExcelPackage ep = new ExcelPackage();
            ExcelWorksheet Sheet = ep.Workbook.Worksheets.Add("Dangngu");

            Sheet.Cells["A1"].Value = "Mã sinh viên";
            Sheet.Cells["B1"].Value = "Họ sinh viên";
            Sheet.Cells["C1"].Value = "Tên sinh viên";
            Sheet.Cells["D1"].Value = "Giới tính";
            Sheet.Cells["E1"].Value = "Ngày sinh";
            Sheet.Cells["F1"].Value = "Quê quán";
            Sheet.Cells["G1"].Value = "Số điện thoại";
            Sheet.Cells["H1"].Value = "Lớp";
            Sheet.Cells["I1"].Value = "Điểm trung bình học kỳ";

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

                string tenlop = "";
                var lops = db.Lops.ToList();
                foreach (var lop in lops)
                {
                    if (lop.MaLop == sv.MaLop)
                    {
                        tenlop = lop.TenLop;
                    }
                }

                Sheet.Cells[string.Format("H{0}", row)].Value = tenlop;
                Sheet.Cells[string.Format("I{0}", row)].Value = sv.DiemTBHK;
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + "Dangngu.xlsx");
            Response.BinaryWrite(ep.GetAsByteArray());
            Response.End();
        }

        [HttpPost]
        [ThanhVienAuthorize(MaChucNang = "TKSV")]
        public JsonResult TimKiemSinhVien(string MaSinhVien, string TenSinhVien, string MaKhoa, string MaLop)
        {
            var ds = SinhVienBUS.DanhSachSinhVien();
            var dsSinhVien = (from item in SinhVienBUS.DanhSachSinhVien().Where(m => m.MaSV.Contains(MaSinhVien.Trim()) && (m.HoSV + " " + m.TenSV).Contains(TenSinhVien.Trim()) && m.MaLop.Contains(MaLop))
                              select new
                              {
                                  MaSV = item.MaSV,
                                  HoSV = item.HoSV,
                                  TenSV = item.TenSV,
                                  GioiTinh = item.GioiTinh,
                                  NgaySinh = String.Format("{0: dd-MM-yyyy}", item.NgaySinh),
                                  QueQuan = item.QueQuan,
                                  SoDienThoai = item.SoDienThoai,
                                  TenLop = LopBUS.LopTheoSinhVien(item.MaLop).TenLop,
                              }).ToList();
            return Json(new { dsSinhVien = dsSinhVien }, JsonRequestBehavior.AllowGet);
        }
    }
}