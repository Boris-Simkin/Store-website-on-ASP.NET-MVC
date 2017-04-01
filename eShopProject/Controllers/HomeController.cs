using AutoMapper;
using DAL;
using DAL.Models;
using eShopProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace eShopProject.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository repo = new ProductRepository();
        // GET: Home
        public ActionResult Main()
        {
            var DALproducts = repo.List;
            //Converting the Product entity from the DAL
            List<ProductView> products = Mapper.Map<List<Product>, List<ProductView>>(DALproducts);
            return View(products);
        }
        public ActionResult FilterOrderList(List<int> checkedProducts)
        {
            //Getting the list of products from the session
            List<ProductView> products = (List<ProductView>)Session["ShoppingCard"];
            List<ProductView> filteredProducts = new List<ProductView>();
            if (checkedProducts != null)
                filteredProducts = products.Where(p => checkedProducts.Exists(cp => cp == p.Id)).ToList();
            //Session["ShoppingCard"] = filteredProducts;
            Session["FilteredShoppingCard"] = filteredProducts;
            //Summarize the total price
            var totalPrice = filteredProducts.Sum(p => p.Price);
            return PartialView("_TotalPrice", totalPrice);
        }

        public ActionResult ShoppingCard()
        {
            List<ProductView> products = new List<ProductView>();
            if (Session["ShoppingCard"] != null)
            {
                products = (List<ProductView>)Session["ShoppingCard"];
            }

            return View(products);
        }

        public ActionResult AddToCard(int id)
        {
            List<ProductView> products = new List<ProductView>();
            if (Session["ShoppingCard"] != null)
            {
                products = (List<ProductView>)Session["ShoppingCard"];
            }
            //Checks if the item already added to the shopping list
            if (products.Exists(p => p.Id == id))
            {
                //Remove the item from the list
                products.Remove(products.First(p => p.Id == id));
                //Assign the new list to the session
                Session["ShoppingCard"] = products;
                Session["FilteredShoppingCard"] = products;
                return PartialView("_AddBtn");
            }

            //Retrieving the product from the db by id
            var DALProduct = repo.Find(id.ToString());
            //Converting the product to view model
            var productView = Mapper.Map<Product, ProductView>(DALProduct);
            //Adding the product the the shopping list
            products.Add(productView);
            //Adding the list to the session
            Session["ShoppingCard"] = products;
            Session["FilteredShoppingCard"] = products;
            return PartialView("_RemoveBtn");
        }

        //the method convertes from Image to byte[]
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        [Authorize]
        public ActionResult SaveProduct(HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, ProductView product)
        {
            if (!ModelState.IsValid)
                return View("AddProduct");

            //Inserting current date
            product.Date = DateTime.Now;
            //Inserting owner name from the cookie
            product.OwnerId = User.Identity.Name;

            byte[] imgData1 = null;
            byte[] imgData2 = null;
            byte[] imgData3 = null;
            //Converting the photos to byte[]
            if (file1 != null)
                imgData1 = imageToByteArray(Image.FromStream(file1.InputStream, true, true));
            if (file2 != null)
                imgData2 = imageToByteArray(Image.FromStream(file2.InputStream, true, true));
            if (file3 != null)
                imgData3 = imageToByteArray(Image.FromStream(file3.InputStream, true, true));

            var DALProduct = Mapper.Map<ProductView, Product>(product);
            repo.AddProduct(DALProduct, imgData1, imgData2, imgData3);
            return RedirectToAction("Main");
        }

        [Authorize]
        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult ProductList(string ButtonType)
        {
            var DALproducts = repo.List;
            //Converting the Product entity from the DAL
            List<ProductView> products = Mapper.Map<List<Product>, List<ProductView>>(DALproducts);
            //Ordering produts by
            switch (ButtonType)
            {
                case "כותרת":
                    return PartialView("_ProductList", products.OrderBy(p => p.Title).ToList());
                case "תאריך":
                    return PartialView("_ProductList", products.OrderBy(p => p.Date).ToList());
                case "מחיר":
                    return PartialView("_ProductList", products.OrderBy(p => p.Price).ToList());
                default:
                    return View(products);
            }
        }
        public ActionResult PurchaseComplete()
        {
            foreach (var item in (List<ProductView>)Session["FilteredShoppingCard"])
            {
                repo.RemoveProduct(item.Id);
            }
            Session["ShoppingCard"] = null;
            Session["FilteredShoppingCard"] = null;
            return View();
        }

        public ActionResult ProductInfo(int id)
        {
            var DALProduct = repo.Find(id.ToString());
            ProductView product = Mapper.Map<Product, ProductView>(DALProduct);
            return View(product);
        }


    }
}