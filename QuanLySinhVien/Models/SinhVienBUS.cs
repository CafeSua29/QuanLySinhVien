using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    public class SinhVienBUS
    {
        public static IEnumerable<SinhVien> DanhSachSinhVien()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<SinhVien> dsSinhVien = 
                from ds in db.SinhViens
                select ds;
            return dsSinhVien;
        }
        public static void ThemSinhVien(int id)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            
        }
    }
}