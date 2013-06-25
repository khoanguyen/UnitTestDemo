using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShoppingWeb.Infrastructure;
using ShoppingWeb.Models;

namespace ShoppingWeb.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {            
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var service = new AccountService();
                if (service.VerifyUser(loginModel))
                {
                    FormsAuthentication.SetAuthCookie(loginModel.UserName, false);
                    Session["username"] = loginModel.UserName;
                    return Redirect(Request.QueryString["ReturnUrl"]);
                }
                ModelState.AddModelError("InvalidLogin","Invalid Login");
            }
            return View(loginModel);
        }

        [ActionName("New")]
        public ActionResult NewAccount()
        {
            if (Request.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View(new NewAccountModel());
        }

        [ActionName("New")]
        [HttpPost]
        public ActionResult NewAccount(NewAccountModel newAccountModel)
        {
            if (ModelState.IsValid)
            {
                var service = new AccountService();
                try
                {                    
                    service.AddNewUser(newAccountModel);
                    FormsAuthentication.RedirectToLoginPage();
                }
                catch (UpdateException updateEx)
                {
                    var sqlEx = updateEx.InnerException as SqlException;
                    ModelState.AddModelError("NewUserError",
                                             sqlEx.Number == 2601
                                                 ? "This UserName is already used by another user"
                                                 : "Database error while creating new user");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("NewUserError", "Unknown error while creating new user");
                }
            }
            return View(newAccountModel);
        }
    }
}
