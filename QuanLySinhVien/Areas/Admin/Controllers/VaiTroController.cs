using QuanLySinhVien.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySinhVien.Areas.Admin.Controllers
{
    public class VaiTroController : Controller
    {
        // GET: Admin/VaiTro
        public ActionResult DanhSachVaiTro()
        {
            return View(VaiTroBUS.DanhSachVaiTro());
        }

        public ActionResult ThemVaiTro()
        {
            return View();
        }
    }
}