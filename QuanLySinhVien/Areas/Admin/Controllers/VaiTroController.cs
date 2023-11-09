using QuanLySinhVien.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.App_Start;
using QuanLySinhVien.Models;
using QuanLySinhVien.Models.ViewModel;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Data.Entity.Migrations;

namespace QuanLySinhVien.Areas.Admin.Controllers
{
    [AdminAuthorite]
    public class VaiTroController : Controller
    {
        QuanLySinhVienEntities db = new QuanLySinhVienEntities();
        // GET: Admin/VaiTro
        public ActionResult DanhSachVaiTro()
        {
            return View(VaiTroBUS.DanhSachVaiTro());
        }

        public ActionResult ThemVaiTro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemVaiTro(VaiTro vt, List<ChucNangSelection> lcns)
        {
            if (ModelState.IsValid)
            {
                var check = db.VaiTroes.FirstOrDefault(m => m.MaVT.Equals(vt.MaVT));
                if (check == null)
                {
                    db.VaiTroes.Add(vt);
                    foreach(ChucNangSelection item in lcns)
                    {
                        if(item.IsSelected == true)
                        {
                            db.PhanQuyens.Add(new PhanQuyen()
                            {
                                MaVT = vt.MaVT,
                                MaCN = item.CN.MaCN
                            });
                        }
                    }
                    db.SaveChanges();
                    return RedirectToAction("DanhSachVaiTro");
                }
                else 
                {
                    TempData["Error"] = "Mã vai trò đã được sử dụng";
                    return View(vt);
                }
            }
            else
            {
                return View(vt);
            }
        }
        public ActionResult SuaVaiTro(string MaVT)
        {
            return View(VaiTroBUS.ChiTietVaiTro(MaVT));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaVaiTro(VaiTro vt, List<ChucNangSelection> lcns)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                db.VaiTroes.AddOrUpdate(vt);
                db.SaveChanges();
                PhanQuyenBUS.CapNhatQuyen(vt.MaVT, lcns);
                return RedirectToAction("DanhSachVaiTro");
            }
            else
            {
                TempData["Error"] = "Không thể sửa vai trò";
                return View(vt);
            }
        }

        public ActionResult XoaVaiTro(string MaVT)
        {
            VaiTro DeleteModel = db.VaiTroes.Find(MaVT);
            db.VaiTroes.Remove(DeleteModel);
            db.SaveChanges();
            return RedirectToAction("DanhSachVaiTro");
        }
    }
}