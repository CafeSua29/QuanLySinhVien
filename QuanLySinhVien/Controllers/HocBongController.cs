﻿using System;
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
    }
}