using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingWeb.Infrastructure.Domain;

namespace ShoppingWeb.Models
{
    public class CartItem
    {
        public Product Product { get; set; }

        private int _quantity;

        public int Quantity 
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                if (Product.Price != null) ItemTotal = _quantity*Product.Price.Value;
            }
        }

        public decimal ItemTotal { get; private set; }
    }
}