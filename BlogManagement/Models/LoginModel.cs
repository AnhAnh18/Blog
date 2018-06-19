using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogManagement.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public String PassWord { get; set; }

        public Boolean Remember { get; set; }
    }
}