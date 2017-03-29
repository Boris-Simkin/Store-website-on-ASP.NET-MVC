using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eShopProject.Models
{
    public class UserView
    {
        [StringLength(30, ErrorMessage = "אורך השם בין 2-30 תווים", MinimumLength = 2)]
        [Display(Name = "הכנס שם פרטי")]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage = "אורך שם המשפחה בין 2-30 תווים", MinimumLength = 2)]
        [Display(Name = "הכנס שם משפחה")]
        public string LastName { get; set; }
        [Display(Name = "הכנס תאריך לידה")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? BirthDate { get; set; }
        [EmailAddress(ErrorMessage = "דואר אלקטרוני שגוי")]
        [Display(Name = "הכנס דואר אלקטרוני")]
        public string Email { get; set; }
        [StringLength(30, ErrorMessage = "אורך שם המשתמש בין 2-30 תווים", MinimumLength = 2)]
        [Required(ErrorMessage = "הכנס שם משתמש")]
        [Display(Name = "הכנס שם משתמש")]
        public string Username { get; set; }
        [Required(ErrorMessage = "הכנס סיסמה")]
        [Display(Name = "הכנס סיסמה")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "אורך הסיסמה בין 4-10 תווים", MinimumLength = 4)]
        public string Password { get; set; }
        [Required(ErrorMessage = "הכנס סיסמה שנית")]
        [Display(Name = "הכנס סיסמה שנית")]
        [Compare("Password", ErrorMessage = "הסיסמאות לא תואמות")]
        public string PasswordConfirm { get; set; }
    }
}