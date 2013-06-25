using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShoppingWeb.Infrastructure;
using ShoppingWeb.UnitTest.TestClasses;

namespace ShoppingWeb.UnitTest
{
    [TestFixture]
    public class ProductServiceTest
    {
        [Test]
        public void TestAllProduct()
        {
            var service = new ProductService()
                {
                    ProductRepository = new FakeProductRepository()
                };

            var result = service.AllProducts();

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void TestAllProductButEmpty()
        {
            var service = new ProductService()
            {
                ProductRepository = new EmptyFakeProductRepository()
            };

            var result = service.AllProducts();

            Assert.NotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
