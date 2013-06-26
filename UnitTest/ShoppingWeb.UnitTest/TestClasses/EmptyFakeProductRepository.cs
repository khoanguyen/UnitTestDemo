using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingWeb.Infrastructure.Domain;

namespace ShoppingWeb.UnitTest.TestClasses
{
    public class EmptyFakeProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public IEnumerable<Product> AllProducts()
        {
            return _products.ToArray();
        }

        public Product FindById(int id)
        {
            return _products.SingleOrDefault(p => p.ProductId == id);
        }
    }

}
