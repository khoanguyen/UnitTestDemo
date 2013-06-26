using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using ShoppingWeb.Infrastructure.Domain;
using ShoppingWeb.Models;

namespace ShoppingWeb.Infrastructure
{
    public class CartService
    {
        public const string CartKey = "cart";

        private HttpSessionState _session;

        public HttpSessionState Session
        {
            get { return _session ?? (_session = HttpContext.Current.Session); }
            set { _session = value; }
        }

        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository()); }
            set { _userRepository = value; }
        }  

        public int AddToCart(int productId)
        {
            using (var context = new ShoppingWebDBEntities())
            {
                
                var product = context.Products.Single(p => p.ProductId == productId);
                var cart = GetCartFromSession();
                if (cart.ContainsKey(productId)) cart[productId].Quantity++;
                else
                {
                    cart[productId] = new CartItem
                        {
                            Product = product,
                            Quantity = 1
                        };
                }
                return cart.Sum(kp => kp.Value.Quantity);
            }
        }

        public CartModel GetCart()
        {
            // TODO : Calculate CartModel's SubTotal, Total, Discount
            CartModel cart = new CartModel
                                    {
                                        CartItems = GetCartFromSession().Select(kp => kp.Value)
                                    };
            cart.SubTotal = cart.CartItems.Sum(item => item.ItemTotal);
            var accPoint = new AccountService().UserRepository.FindByUserName((string)Session["username"]).Point;
            cart.Total = CalculateOrder(accPoint, cart.SubTotal);
            //cart.Discount = (decimal) (accPoint > 200
            //                               ? 0.15
            //                               : accPoint >= 100
            //                                     ? 0.1
            //                                     : accPoint >= 50
            //                                           ? 0.05
            //                                           : 0);
            //cart.Total = cart.SubTotal*(1 - cart.Discount);
            return cart;
        }

        public decimal CalculateOrder(int accPoint, decimal orderTotal)
        {
            decimal discount = (decimal) (accPoint > 200
                                           ? 0.15
                                           : accPoint >= 100
                                                 ? 0.1
                                                 : accPoint >= 50
                                                       ? 0.05
                                                       : 0);
            return orderTotal*(1 - discount);
        }

        private Dictionary<int, CartItem> GetCartFromSession()
        {
            Session[CartKey] = Session[CartKey] ?? new Dictionary<int, CartItem>();
            return (Dictionary<int, CartItem>)Session[CartKey];
        }
    }
}