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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TaiKhoan
    {
        [Required(ErrorMessage = "nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "nhập mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[a-z])(?=.*\d).{8,15}$", ErrorMessage = "Mật khẩu phải có độ dài tối thiểu 8 kí tự, có kí tự hoa, số ")]
        public string Password { get; set; }
    
        public virtual ThanhVien ThanhVien { get; set; }
    }
}