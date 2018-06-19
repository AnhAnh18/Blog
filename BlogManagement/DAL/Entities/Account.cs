using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogManagement.DAL.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Username phải dài hơn 6 kí tự!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "UserName")]
        public String UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public String PassWord { get; set; }
        
        public String Image { get; set; }
        
        public bool isAdmin { get; set; }

        public bool EmailConfirmed { get; set; }

        public Account()
        {
            isAdmin = false;
            EmailConfirmed = false;
        }

        public Account(int id, string email, string userName, string passWord, string image, bool isAdmin, bool emailConfirmed)
        {
            AccountId = id;
            Email = email;
            UserName = userName;
            PassWord = passWord;
            Image = image;
            this.isAdmin = isAdmin;
            EmailConfirmed = emailConfirmed;
        }
    }
}