using AutoMapper;
using DAL;
using DAL.Models;
using eShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eShopProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Main()
        {
            ProductManager pm = new ProductManager();
            var DALproducts = pm.GetProducts();
            //Converting the Product entity from the DAL
            List<ProductView> products = Mapper.Map<List<Product>, List<ProductView>>(DALproducts);
            return View(products);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User u)
        {
            if (!ModelState.IsValid)
            {

            }
            //Adding the user to the DataBase

            return RedirectToAction("Main", "Home");
        }


    }
}