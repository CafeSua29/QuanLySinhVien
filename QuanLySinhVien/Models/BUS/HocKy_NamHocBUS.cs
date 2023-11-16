using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class HocKy_NamHocBUS
    {
        public static IEnumerable<HocKy_NamHoc> DanhSachHocKy()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<HocKy_NamHoc> dsHocKy = 
                from ds in db.HocKy_NamHoc
                select ds;
            return dsHocKy;
        }
    }
}