﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models.ViewModel
{
    public class ChangePasswordModel
    {
        public string CurrentPassword { get; set;}
        public string NewPassword { get; set;}
        public string ConfirmPassword { get; set;}
    }
}