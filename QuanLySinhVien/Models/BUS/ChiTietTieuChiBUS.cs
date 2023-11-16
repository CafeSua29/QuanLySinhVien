using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class ChiTietTieuChiBUS
    {
        public static ChiTietTieuChi ChiTietTieuChiTheoBangDRL_TieuChi(int MaBangDRL, int MaTieuChi) 
        {
            QuanLySinhVienEntities db = new QuanLySinhVienEntities();
            return db.ChiTietTieuChis.FirstOrDefault(m => m.MaBangDRL == MaBangDRL && m.MaTieuChi == MaTieuChi);
        }
    }
}