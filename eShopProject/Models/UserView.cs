using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eShopProject.Models
{
    public class UserView
    {
        public int UserId { get; set; }
        [Display(Name = "הכנס שם פרטי")]
        public string FirstName { get; set; }
        [Display(Name = "הכנס שם משפחה")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [Display(Name = "הכנס שם דואר אלקטרוני")]
        public string Email { get; set; }
        [Display(Name = "הכנס שם משתמש")]
        public string Username { get; set; }
        [Display(Name = "הכנס סיסמה")]
        public string Password { get; set; }
    }
}