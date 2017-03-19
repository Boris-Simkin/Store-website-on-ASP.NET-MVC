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
        public string LongDescription { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public byte[] Picture1 { get; set; }
        public byte[] Picture2 { get; set; }
        public byte[] Picture3 { get; set; }
        
    }
}