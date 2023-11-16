using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class MucTieuChiBUS
    {
        public static IEnumerable<MucTieuChi> DanhSachMucTieuChi()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<MucTieuChi> dsMTC = 
                from ds in db.MucTieuChis
                select ds;
            return dsMTC;
        }
    }
}