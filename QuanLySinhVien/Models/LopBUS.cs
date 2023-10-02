using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    public class LopBUS
    {
        public static IEnumerable<Lop> DanhSachLop()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<Lop> dsLop = 
                from ds in db.Lops
                select ds;
            return dsLop;
        }
    }
}