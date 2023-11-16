using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class ThanhVienBUS
    {
        public static IEnumerable<ThanhVien> DanhSachThanhVien()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<ThanhVien> dsThanhVien = 
                from ds in db.ThanhViens
                select ds;
            return dsThanhVien;
        }
        public static ThanhVien ChiTietThanhVien(string UserName)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            return db.ThanhViens.FirstOrDefault(m => m.UserName == UserName);
        }
    }
}