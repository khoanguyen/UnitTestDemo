using System.Web.Mvc;
using ShoppingWeb.Infrastructure;

namespace ShoppingWeb.Controllers
{
    [Authorize]
    public class HomeController : BaseController
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
            CartService service = new CartService();
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
