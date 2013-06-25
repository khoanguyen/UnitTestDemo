using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models
{
    public class AccountViewModel
    {
        public LoginModel LoginModel { get; set; }
        public NewAccountModel NewAccountModel { get; set; }

        public AccountViewModel()
        {
            LoginModel = new LoginModel();
            NewAccountModel = new NewAccountModel();
        }


    }
}