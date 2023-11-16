using QuanLySinhVien.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace QuanLySinhVien.Models.BUS
{
    public class PhanQuyenBUS
    {
        //public static void ThemQuyen(string MaVT, string MaCN)
        //{
        //    using (var db = new QuanLySinhVienEntities())
        //    {
        //        var check = db.PhanQuyens.SingleOrDefault(m => m.MaVT == MaVT && m.MaCN == MaCN);
        //        if (check == null)
        //        {
        //            PhanQuyen model = new PhanQuyen();
        //            {
        //                model.MaVT = MaVT;
        //                model.MaCN = MaCN;
        //            }
        //            db.PhanQuyens.Add(model);
        //            db.SaveChanges();
        //        }
        //    }
        //}

        public static void XoaQuyen(string MaVT, string MaCN)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            var DeleteModel = db.PhanQuyens.SingleOrDefault(m => m.MaVT == MaVT && m.MaCN == MaCN);
            if (DeleteModel != null)
            {
                db.PhanQuyens.Remove(DeleteModel);
            }
            db.SaveChanges();
        }

        public static void CapNhatQuyen(string MaVT, List<ChucNangSelection> lcns)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IEnumerable<PhanQuyen> dsQ = db.PhanQuyens.Where(m => m.MaVT.Equals(MaVT));
            db.PhanQuyens.RemoveRange(dsQ);
            foreach (ChucNangSelection item in lcns)
            {
                if (item.IsSelected == true)
                {
                    db.PhanQuyens.Add(new PhanQuyen()
                    {
                        MaVT = MaVT,
                        MaCN = item.CN.MaCN
                    });
                }
            }
            db.SaveChanges();
        }

        public static IEnumerable<PhanQuyen> DanhSachQuyenTheoVaiTro(string MaVT)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<PhanQuyen> dsQuyen =
                from ds in db.PhanQuyens
                where ds.MaVT == MaVT
                select ds;
            return dsQuyen;
        }
    }
}