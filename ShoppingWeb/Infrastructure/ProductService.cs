using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingWeb.Infrastructure.Domain;

namespace ShoppingWeb.Infrastructure
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public IProductRepository ProductRepository
        {
            get { return _productRepository ?? (_productRepository = new ProductRepository()); }
            set { _productRepository = value; }
        }       

        public IEnumerable<Product> AllProducts()
        {
            return ProductRepository.AllProducts();
        }
    }
}