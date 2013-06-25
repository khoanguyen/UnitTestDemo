using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingWeb.Infrastructure.Domain;

namespace ShoppingWeb.Infrastructure
{
    public class ProductService
    {
        public IEnumerable<Product> AllProduct()
        {
            using (var context = new ShoppingWebDBEntities())
            {
                return context.Products.ToArray();
            }
        }
    }
}