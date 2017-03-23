using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopProject.Models
{
    public class ProductImageView
    {
        public int ProductImageId { get; set; }
        public byte[] Picture1 { get; set; }
        public byte[] Picture2 { get; set; }
        public byte[] Picture3 { get; set; }
    }
}