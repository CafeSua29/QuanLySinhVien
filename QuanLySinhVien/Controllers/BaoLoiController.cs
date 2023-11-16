using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.App_Start;

namespace QuanLySinhVien.Controllers
{
    public class BaoLoiController : Controller
    {
        // GET: BaoLoi
        [ThanhVienAuthorize(MaChucNang = "KCQ")]
        public ActionResult KhongCoQuyen()
        {
            return View();
        }
    }
}