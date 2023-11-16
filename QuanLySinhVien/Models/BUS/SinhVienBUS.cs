using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
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
        public static SinhVien ChiTietSinhVienTheoBangDRL(string MaSV)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            return db.SinhViens.FirstOrDefault(m => m.MaSV.Equals(MaSV));
        }
    }
}