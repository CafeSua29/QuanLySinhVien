using QuanLySinhVien.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySinhVien.Controllers
{
    public class DiemRenLuyenController : Controller
    {
        // GET: DiemRenLuyen
        public ActionResult DanhSachBangDiemRenLuyen()
        {
            return View();
        }

        public ActionResult ChiTietBangDiemRenLuyen() 
        {
            return View(BangDiemRenLuyenBUS.ChiTietBangDRL(1));
        }   
    }
}