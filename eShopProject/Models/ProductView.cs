using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopProject.Models
{
    public class ProductView
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }

    }
}