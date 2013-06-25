using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Infrastructure.Domain
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> AllProducts()
        {
            using (var context = new ShoppingWebDBEntities())
            {
                return context.Products.ToArray();
            }
        }

        public Product FindById(int id)
        {
            using (var context = new ShoppingWebDBEntities())
            {
                return context.Products.SingleOrDefault(p => p.ProductId == id);
            }
        }
    }
}