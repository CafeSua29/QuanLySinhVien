﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLySinhVienEntities : DbContext
    {
        public QuanLySinhVienEntities()
            : base("name=QuanLySinhVienEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BangDiemRenLuyen> BangDiemRenLuyens { get; set; }
        public virtual DbSet<ChiTietTieuChi> ChiTietTieuChis { get; set; }
        public virtual DbSet<ChucNang> ChucNangs { get; set; }
        public virtual DbSet<HocBong> HocBongs { get; set; }
        public virtual DbSet<HocKy> HocKies { get; set; }
        public virtual DbSet<HocKy_NamHoc> HocKy_NamHoc { get; set; }
        public virtual DbSet<KetQua> KetQuas { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<MucTieuChi> MucTieuChis { get; set; }
        public virtual DbSet<NamHoc> NamHocs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<QuanTriVien> QuanTriViens { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }
        public virtual DbSet<TieuChi> TieuChis { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }
    }
}
