using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.ViewModel
{
    public class ChangePasswordModel
    {
        public string CurrentPassword { get; set;}
        [RegularExpression(@"^(?=.*[a-z])(?=.*[a-z])(?=.*\d).{8,15}$", ErrorMessage = "mật khẩu phải có độ dài tối thiểu 8 kí tự, có kí tự hoa, số ")]

        [Required(ErrorMessage = "nhập mật khẩu")]
        public string NewPassword { get; set;}
        [Compare("NewPassword", ErrorMessage = "không trùng với mật khẩu mới")]
        public string ConfirmPassword { get; set;}
    }
}