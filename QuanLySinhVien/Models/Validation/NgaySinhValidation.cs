using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.Validation
{
    public class NgaySinhValidation : ValidationAttribute
    {
        public NgaySinhValidation()
        {
            ErrorMessage = "Ngày tháng năm sinh không hợp lệ";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            DateTime date = DateTime.Parse(value.ToString());
            bool CheckTuoi = (DateTime.Now.Year - date.Year) >= 18;
            return CheckTuoi;
        }
    }
    
}