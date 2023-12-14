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
        public static IEnumerable<SinhVien> DanhSachSinhVien_HB(int MaHK_NH)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<SinhVien> dssv =
                from sv in db.SinhViens
                where (from kq in db.KetQuas join mh in db.MonHocs on kq.MaMH equals mh.MaMH where mh.MaHK_NH == MaHK_NH select kq).Count() > 0 && (from kq in db.KetQuas join mh in db.MonHocs on kq.MaMH equals mh.MaMH where kq.Diem < 4 && kq.MaSV == sv.MaSV && mh.MaHK_NH == MaHK_NH select kq).Count() == 0
                select sv;
            return dssv;
        }
    }
}