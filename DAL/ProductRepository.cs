using DAL.DB;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository : IRepository<Product>
    {
        public List<Product> List
        {
            get
            {
                var products = new List<Product>();
                using (var context = new EShopEntities())
                {
                    products = context.Products.ToList();
                }
                return products;
            }
        }

        public Product Find(string id)
        {
            int intId = int.Parse(id);
            var product = new Product();
            using (var context = new EShopEntities())
            {
                product = context.Products.Where(p => p.Id == intId).First();
            }
            return product;
        }

        /// <summary>
        /// Return all images of specific product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductImage GetImages(int productId)
        {
            var images = new ProductImage();
            using (var context = new EShopEntities())
            {
                images = (from p in context.Products
                          where p.Id == productId
                          select p.ProductImage).First();
            }
            return images;
        }

        public void AddProduct(Product product, byte[] image1, byte[] image2, byte[] image3)
        {
            product.ProductImage = new ProductImage();
            product.ProductImage.Picture1 = image1;
            product.ProductImage.Picture2 = image2;
            product.ProductImage.Picture3 = image3;

            using (var context = new EShopEntities())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        //Remove product by id
        public void RemoveProduct(int productId)
        {
            using (var context = new EShopEntities())
            {
                context.Products.Remove(context.Products.First(p => p.Id == productId));
                context.SaveChanges();
            }
        }

    }
}
