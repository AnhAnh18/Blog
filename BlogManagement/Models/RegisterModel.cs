using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên người dùng")]
        public String UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public String PassWord { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public String ComfirmPass { get; set; }

        public int codeVerify { get; set; }
    }
}