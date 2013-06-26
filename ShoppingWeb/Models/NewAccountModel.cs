using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWeb.Models
{
    public class NewAccountModel
    {
        [Required(ErrorMessage = "UserName is required")]
        [DisplayName("UserName")]
        [RegularExpression("^[0-9a-zA-Z]{8,20}$", ErrorMessage = "Invalid UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DisplayName("Confirm Password")]
        [PasswordPropertyText]
        [Compare("Password", ErrorMessage = "Password and Confirm Password are not matched")]
        public string ConfirmPassword { get; set; }
    }
}