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
    public class ImagesController : Controller
    {
        // GET: Images
        public FileResult ShowImage(int id, int imageNumber)
        {
            ProductManager pm = new ProductManager();
            var DALproductImages = pm.GetImages(id);
            //Converting the Image entity from the DAL
            var images = Mapper.Map<ProductImage, ProductImageView>(DALproductImages);
            byte[] res = images.Picture1;
            switch (imageNumber)
            {
                case 1:
                    res = images.Picture1;
                    break;
                case 2:
                    res = images.Picture2;
                    break;
                case 3:
                    res = images.Picture3;
                    break;
                default:
                    break;
            }

            return File(res, "image/jpeg");
        }
    }
}