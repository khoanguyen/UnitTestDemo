using System.Collections.Generic;
using NUnit.Framework;
using ShoppingWeb.Infrastructure;
using ShoppingWeb.Infrastructure.Domain;
using ShoppingWeb.Models;

namespace ShoppingWeb.UnitTest
{
    [TestFixture]
    class CartServiceTest
    {
        private CartService _cartService;
        [SetUp]
        public void SetUp()
        {
            _cartService = new CartService();
        }

        [Test]
        [TestCaseSource("GetTestData")]
        public void CalculateOrderTest(string message, User user, CartModel cart, decimal expectedResult)
        {
            _cartService.CalculateOrder(user, cart);
            Assert.AreEqual(expectedResult, cart.Total, message);
        }


        private IEnumerable<object> GetTestData()
        {
            return new[]
                       {
                           new object[]
                               {
                                   "< 50 - no discount", new User {Password = "password", UserName = "tham.vo", Point = 25},
                                   new CartModel {SubTotal = 10000}, new decimal(10000)
                               },
                           new object[]
                               {
                                   "just below 50 - no discount", new User {Password = "password", UserName = "tham.vo", Point = 49},
                                   new CartModel {SubTotal = 10000}, new decimal(10000)
                               },
                           new object[]
                               {
                                   "equal 50 - 5% discount", new User {Password = "password", UserName = "tham.vo", Point = 50},
                                   new CartModel {SubTotal = 10000}, new decimal(9500)
                               },
                           new object[]
                               {
                                   "just above 50 - 5% discount", new User {Password = "password", UserName = "tham.vo", Point = 51},
                                   new CartModel {SubTotal = 10000}, new decimal(9500)
                               },
                           new object[]
                               {
                                   "in range 50-100 - 5% discount", new User {Password = "password", UserName = "tham.vo", Point = 70},
                                   new CartModel {SubTotal = 10000}, new decimal(9500)
                               },
                           new object[]
                               {
                                   "just below 100 - 5% discount", new User {Password = "password", UserName = "tham.vo", Point = 99},
                                   new CartModel {SubTotal = 10000}, new decimal(9500)
                               },
                           new object[]
                               {
                                   "equal 100 - 10% discount", new User {Password = "password", UserName = "tham.vo", Point = 100},
                                   new CartModel {SubTotal = 10000}, new decimal(9000)
                               },
                           new object[]
                               {
                                   "just above 100 - 10% discount", new User {Password = "password", UserName = "tham.vo", Point = 101},
                                   new CartModel {SubTotal = 10000}, new decimal(9000)
                               },
                           new object[]
                               {
                                   "in range 100-200 - 10% discount", new User {Password = "password", UserName = "tham.vo", Point = 149},
                                   new CartModel {SubTotal = 10000}, new decimal(9000)
                               },
                           new object[]
                               {
                                   "just below 200 - 10% discount", new User {Password = "password", UserName = "tham.vo", Point = 199},
                                   new CartModel {SubTotal = 10000}, new decimal(9000)
                               },
                           new object[]
                               {
                                   "equal 200 - 10% discount", new User {Password = "password", UserName = "tham.vo", Point = 200},
                                   new CartModel {SubTotal = 10000}, new decimal(9000)
                               },
                           new object[]
                               {
                                   "just above 200 - 15% discount", new User {Password = "password", UserName = "tham.vo", Point = 201},
                                   new CartModel {SubTotal = 10000}, new decimal(8500)
                               },
                           new object[]
                               {
                                   "> 200 - 15% discount", new User {Password = "password", UserName = "tham.vo", Point = 525},
                                   new CartModel {SubTotal = 10000}, new decimal(8500)
                               },
                           new object[]
                               {
                                   "equal 0 - no discount", new User {Password = "password", UserName = "tham.vo", Point = 0},
                                   new CartModel {SubTotal = 10000}, new decimal(10000)
                               },
                           new object[]
                               {
                                   "< 0 - no disount", new User {Password = "password", UserName = "tham.vo", Point = -2},
                                   new CartModel {SubTotal = 10000}, new decimal(10000)
                               }
                       };
        } 
    }
}
