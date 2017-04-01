using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eShopProject.Models
{
    public class ProductView
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        [Required(ErrorMessage = "הכנס כותרת")]
        [Display(Name = "כותרת")]
        public string Title { get; set; }
        [Display(Name = "תיאור קצר")]
        public string ShortDescription { get; set; }
        [Display(Name = "תיאור ארוך")]
        public string LongDescription { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "הכנס מחיר")]
        [Display(Name = "מחיר")]
        public double Price { get; set; }

    }
}