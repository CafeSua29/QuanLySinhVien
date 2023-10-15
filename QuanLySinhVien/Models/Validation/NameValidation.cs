using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.Validation
{
    public class NameValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            string name = value.ToString();
            if (!Char.IsLetter(name[0]))
            {
                return false;
            }

            if (!Char.IsLetter(name[name.Length - 1]))
            {
                return false;
            }

            return name.All(c => Char.IsLetter(c) || c == ' ');
        }
    }
}