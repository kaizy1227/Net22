using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetCuoiKy.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage ="Vui lòng nhập tên đăng nhập!")]
        public string Username { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Độ dài mật khẩu ít nhất 6 ký tự!")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ tên!")]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email!")]
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }


    }
}