using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eShopProject.Models
{
    public class LoginView
    {
        [Required(ErrorMessage = "הכנס שם משתמש")]
        [Display(Name = "הכנס שם משתמש")]
        public string Username { get; set; }
        [Required(ErrorMessage = "הכנס סיסמה")]
        [Display(Name = "הכנס סיסמה")]
        public string Password { get; set; }
    }
}