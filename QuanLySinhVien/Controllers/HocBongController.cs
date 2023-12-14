using QuanLySinhVien.Models.BUS;
using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySinhVien.Controllers
{
    public class HocBongController : Controller
    {
        // GET: HocBong
        public ActionResult DanhSachHocBong()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DanhSachSV_HB(int MaHK_NH)
        {
            var sl = (from sv in SinhVienBUS.DanhSachSinhVien_HB(MaHK_NH) select sv).Count();
            var dsSV_HB = (from sv in SinhVienBUS.DanhSachSinhVien_HB(MaHK_NH)
                            select new
                            {
                                MaSV = sv.MaSV,
                                HoSV = sv.HoSV,
                                TenSV = sv.TenSV,
                                GioiTinh = sv.GioiTinh,
                                NgaySinh = String.Format("{0: dd-MM-yyyy}", sv.NgaySinh),
                                TenLop = LopBUS.LopTheoSinhVien(sv.MaLop).TenLop,
                            }).ToList();
            return Json(new { dsSV_HB = dsSV_HB }, JsonRequestBehavior.AllowGet);
        }
    }
}