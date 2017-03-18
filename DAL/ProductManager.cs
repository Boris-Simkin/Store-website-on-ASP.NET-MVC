using DAL.DB;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductManager
    {
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            using (var context = new EShopEntities())
            {
                products = context.Products.ToList();
            }
            return products;
        }
    }
}
