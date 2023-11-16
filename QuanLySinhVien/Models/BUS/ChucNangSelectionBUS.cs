using QuanLySinhVien.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.BUS
{
    public class ChucNangSelectionBUS
    {
        public static List<ChucNangSelection> DanhSachChucNangSelection()
        {
            List<ChucNangSelection> dsCNS = new List<ChucNangSelection>();
            foreach(var item in ChucNangBUS.DanhSachChucNang())
            {
                dsCNS.Add(new ChucNangSelection()
                {
                    CN = item,
                });
            }
            return dsCNS;
        }

        public static List<ChucNangSelection> DanhSachChucNangSelectionTheoVT(string MaVT)
        {
            List<ChucNangSelection> dsCNS = new List<ChucNangSelection>();
            foreach (var item in ChucNangBUS.DanhSachChucNang())
            {
                bool selected = false;
                foreach (var item2 in PhanQuyenBUS.DanhSachQuyenTheoVaiTro(MaVT))
                {
                    if(item.MaCN == item2.MaCN) selected = true;
                }
                dsCNS.Add(new ChucNangSelection()
                {
                    CN = item,
                    IsSelected = selected
                });
            }
            return dsCNS;
        }
    }
}