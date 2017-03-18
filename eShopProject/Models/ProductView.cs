using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopProject.Models
{
    public class ProductView
    {
        public int ProductId { get; set; }
        //public ICollection<User> Owners { get; set; }
        //public ICollection<User> Users { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
    }
}