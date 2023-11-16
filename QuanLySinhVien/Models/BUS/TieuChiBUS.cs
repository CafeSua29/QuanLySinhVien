using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class TieuChiBUS
    {
        public static IEnumerable<TieuChi> DanhSachTieuChiTheoMuc(int MaMucTieuChi)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<TieuChi> dsTC =
                from ds in db.TieuChis
                where ds.MaMucTieuChi == MaMucTieuChi
                select ds;
            return dsTC;
        }
    }
}