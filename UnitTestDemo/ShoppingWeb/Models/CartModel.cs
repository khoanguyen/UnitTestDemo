using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models
{
    public class CartModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}