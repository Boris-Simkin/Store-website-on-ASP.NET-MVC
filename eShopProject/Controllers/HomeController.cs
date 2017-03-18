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
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Product, ProductView>();
            });
            List<ProductView> products = Mapper.Map<List<Product>, List<ProductView>>(DALproducts);
            
            return View(products);
        }
    }
}