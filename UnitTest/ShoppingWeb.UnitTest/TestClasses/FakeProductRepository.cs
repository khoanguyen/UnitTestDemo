using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingWeb.Infrastructure.Domain;

namespace ShoppingWeb.UnitTest.TestClasses
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>()
            {
                new Product { ProductId = 1, ProductName = "AK-47", Price = (decimal)1999.99, Photo = "ak47.jpg" },
                new Product { ProductId = 2, ProductName = "F-2000 Assault Rifle", Price = 3000, Photo = "F-2000-Assault-Rifle.jpg" },
                new Product { ProductId = 3, ProductName = "HK416 Assault Rifle", Price = (decimal)500.50, Photo = "Heckler-and-Koch-HK416-Assault-Rifle.jpg" },
            };

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
