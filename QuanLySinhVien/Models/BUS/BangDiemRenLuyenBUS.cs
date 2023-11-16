using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class BangDiemRenLuyenBUS
    {
        public static IEnumerable<BangDiemRenLuyen> DanhSachBangDRLTheoHK_NH(int MaHK_NH)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<BangDiemRenLuyen> dsBang =
                from ds in db.BangDiemRenLuyens
                where ds.MaHK_NH == MaHK_NH
                select ds;
            return dsBang;
        }

        public static BangDiemRenLuyen ChiTietBangDRL(int MaBangDRL)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            return db.BangDiemRenLuyens.FirstOrDefault(m => m.MaBangDRL == MaBangDRL);
        }
    }
}