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
    using QuanLySinhVien.Models.Validation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            this.KetQuas = new HashSet<KetQua>();
            this.BangDiemRenLuyens = new HashSet<BangDiemRenLuyen>();
            this.HocBongs = new HashSet<HocBong>();
        }

        [Display(Name = "Mã sinh viên")]
        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [RegularExpression(@"^[0-9a-zA-Z]{7}$", ErrorMessage = "Mã sinh viên không hợp lệ")]

        public string MaSV { get; set; }

        [Required(ErrorMessage = "Họ của sinh viên không được để trống")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Họ không hợp lệ")]
        [Display(Name = "Họ sinh viên")]
        [NameValidation(ErrorMessage = "Họ sinh viên không hợp lệ")]
        public string HoSV { get; set; }

        [Required(ErrorMessage = "Tên sinh viên không được để trống")]
        [NameValidation(ErrorMessage = "Tên sinh viên không hợp lệ")]
        [Display(Name = "Tên sinh viên")]

        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Tên không hợp lệ")]
        public string TenSV { get; set; }

        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh chưa được chọn")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [NgaySinhValidation]
        public System.DateTime NgaySinh { get; set; } = DateTime.Now;

        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Quê quán không hợp lệ")]
        [Display(Name = "Quê quán")]
        [Required(ErrorMessage = "Quê quán không được để trống")]
        [NameValidation(ErrorMessage = "Quê quán sinh viên không hợp lệ")]
        public string QueQuan { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^(\+84|0)[0-9]{7,10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SoDienThoai { get; set; }

        [Display(Name = "Lớp quản lý")]
        [Required(ErrorMessage = "Yêu cầu chọn lớp")]
        public string MaLop { get; set; }

        public Nullable<float> DiemTBHK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQua> KetQuas { get; set; }
        public virtual Lop Lop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiemRenLuyen> BangDiemRenLuyens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocBong> HocBongs { get; set; }
    }
}