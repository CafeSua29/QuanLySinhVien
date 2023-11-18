using QuanLySinhVien.Models;
using QuanLySinhVien.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.App_Start;

namespace QuanLySinhVien.Controllers
{
    [ThanhVienAuthorize(MaChucNang = "TKSV")]
    public class DiemRenLuyenController : Controller
    {
        
        QuanLySinhVienEntities db= new QuanLySinhVienEntities();
        // GET: DiemRenLuyen
        public ActionResult DanhSachBangDiemRenLuyen()
        {
            return View();
        }

        public ActionResult ChiTietBangDiemRenLuyen(int MaBangDRL) 
        {
            return View(BangDiemRenLuyenBUS.ChiTietBangDRL(MaBangDRL));
        }

        [HttpPost]   
        
        public JsonResult DanhSachSV_DRL(int MaHK_NH)
        {
            var dsSV_DRL = (from drl in BangDiemRenLuyenBUS.DanhSachBangDRLTheoHK_NH(MaHK_NH) join sv in SinhVienBUS.DanhSachSinhVien() on drl.MaSV equals sv.MaSV
                         select new
                         {
                            MaBangDRL = drl.MaBangDRL,
                            MaSV = sv.MaSV,
                            HoSV = sv.HoSV,
                            TenSV = sv.TenSV,
                            TenLop = LopBUS.LopTheoSinhVien(sv.MaLop).TenLop,
                            DiemTong = drl.DiemTong,
                            DiemToiDa = drl.DiemToiDa,
                         }).ToList();
            return Json(new { dsSV_DRL = dsSV_DRL}, JsonRequestBehavior.AllowGet);
        }
    }
}