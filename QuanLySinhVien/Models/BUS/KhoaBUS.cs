using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class KhoaBUS
    {
        public static IEnumerable<Khoa> DanhSachKhoa()
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            var dsKhoa = 
                from ds in db.Khoas
                select ds;
            return dsKhoa;
        }
        public static Khoa KhoaTheoLop(string lop_MaKhoa) {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            return db.Khoas.SingleOrDefault(m => m.MaKhoa == lop_MaKhoa);
        }
    }
}