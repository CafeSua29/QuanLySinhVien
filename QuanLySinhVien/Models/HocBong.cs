//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLySinhVien.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HocBong
    {
        public int MaHB { get; set; }
        public string MaSV { get; set; }
        public Nullable<float> SoTien { get; set; }
        public int MaHK_NH { get; set; }
    
        public virtual HocKy_NamHoc HocKy_NamHoc { get; set; }
        public virtual SinhVien SinhVien { get; set; }
    }
}