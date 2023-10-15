using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Media.Animation;

namespace QuanLySinhVien.Models
{
    public class LopBUS
    {
        public static IEnumerable<Lop> DanhSachLopTheoKhoa(string MaKhoa)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<Lop> dsLop =
                from ds in db.Lops  
                where ds.MaKhoa == MaKhoa
                select ds;
            return dsLop;
        }
       public static Lop LopTheoSinhVien(string sv_MaLop)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            return db.Lops.SingleOrDefault(m => m.MaLop == sv_MaLop);
        }
    }
}