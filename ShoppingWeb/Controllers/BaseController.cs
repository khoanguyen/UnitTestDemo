using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWeb.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected override void  OnActionExecuting(ActionExecutingContext filterContext)
        {
           if(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "Account" && Session["username"] == null)
           {
               filterContext.Result = RedirectToAction("Index", "Account");
           }
        }

    }
}
