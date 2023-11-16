using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class ChucNangBUS
    {
        public static IEnumerable<ChucNang> DanhSachChucNang()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<ChucNang> dsCN = 
                from ds in db.ChucNangs
                select ds;
            return dsCN;
        }
    }
}