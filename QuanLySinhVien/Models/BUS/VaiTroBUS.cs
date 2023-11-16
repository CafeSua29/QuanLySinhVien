using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class VaiTroBUS
    {
        public static IEnumerable<VaiTro> DanhSachVaiTro()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<VaiTro> dsVT = 
                from ds in db.VaiTroes
                select ds;
            return dsVT;
        }
        public static VaiTro ChiTietVaiTro(string MaVaiTro)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            return db.VaiTroes.FirstOrDefault(m => m.MaVT == MaVaiTro);
        }
    }
}