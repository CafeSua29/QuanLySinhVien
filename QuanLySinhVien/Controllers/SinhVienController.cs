﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChiTietSinhVien()
        {
            return View();
        }
    }
}