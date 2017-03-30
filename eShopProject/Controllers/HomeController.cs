using AutoMapper;
using DAL;
using DAL.Models;
using eShopProject.Models;
using System;
using System.Collections.Generic;
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

        public ActionResult ShoppingCard()
        {
            return View();
        }

        public ActionResult ProductList(string ButtonType)
        {
            var DALproducts = repo.List;
            //Converting the Product entity from the DAL
            List<ProductView> products = Mapper.Map<List<Product>, List<ProductView>>(DALproducts);

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

        public ActionResult ProductInfo(int id)
        {
            var DALProduct = repo.Find(id.ToString());
            ProductView product = Mapper.Map<Product, ProductView>(DALProduct);

            //UserRepository repository = new UserRepository();
            //    UserView user = new UserView();
            //    User DALUser = repository.Find(product.OwnerId);
            //    user = Mapper.Map<User, UserView>(DALUser);
            //    return View(user);


            return View(product);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

    }
}