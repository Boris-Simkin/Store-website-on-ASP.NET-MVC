using AutoMapper;
using DAL.Models;
using eShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eShopProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Mapping the Product entitys to view model
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductImage, ProductImageView>();
                cfg.CreateMap<Product, ProductView>();
            });

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
