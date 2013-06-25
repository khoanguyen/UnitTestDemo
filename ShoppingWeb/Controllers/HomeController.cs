using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingWeb.Infrastructure;
using ShoppingWeb.Infrastructure.Domain;
using ShoppingWeb.Models;

namespace ShoppingWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var service = new ProductService();
            return View(service.AllProducts());
        }

        public ActionResult CheckCart()
        {
            var service = new CartService();
            return View(service.GetCart());
        }

        [HttpPost]
        public JsonResult AddToCart(int productId)
        {
            var service = new CartService();
            return Json(service.AddToCart(productId));
        }

    }
}
