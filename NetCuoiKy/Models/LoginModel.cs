using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetCuoiKy.Models
{
    public class LoginModel
    {
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage = "Mời nhập username")]
        public string Username { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}