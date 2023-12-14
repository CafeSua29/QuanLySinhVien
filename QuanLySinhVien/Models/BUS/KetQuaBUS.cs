using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class KetQuaBUS
    {
        public static IEnumerable<KetQua> DanhSachKetQUaTheoSV(int MaHK_NH, string MaSV)
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            IQueryable<KetQua> dskq =
                from sv in db.SinhViens
                join kq in db.KetQuas on sv.MaSV equals kq.MaSV
                join mh in db.MonHocs on kq.MaMH equals mh.MaMH
                where mh.MaHK_NH == MaHK_NH && kq.MaSV == MaSV
                select kq;
            return dskq;

        }
    }
}