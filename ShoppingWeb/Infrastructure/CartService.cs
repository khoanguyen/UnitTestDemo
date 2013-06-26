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
            CartModel cart = new CartModel
                                    {
                                        CartItems = GetCartFromSession().Select(kp => kp.Value)
                                    };
            cart.SubTotal = cart.CartItems.Sum(item => item.ItemTotal);
            var user = new AccountService().UserRepository.FindByUserName(HttpContext.Current.User.Identity.Name);
            CalculateOrder(user, cart);
            return cart;
        }

        public void ClearCart()
        {
            Session[Keys.CartKey] = new Dictionary<int, CartItem>(); 
        }

        public void CalculateOrder(User user, CartModel cart)
        {
            decimal discount = (decimal) (user.Point > 200
                                           ? 0.15
                                           : user.Point >= 100
                                                 ? 0.1
                                                 : user.Point >= 50
                                                       ? 0.05
                                                       : 0);
            cart.Total = cart.SubTotal*(1 - discount);
        }

        private Dictionary<int, CartItem> GetCartFromSession()
        {
            Session[Keys.CartKey] = Session[Keys.CartKey] ?? new Dictionary<int, CartItem>();
            return (Dictionary<int, CartItem>)Session[Keys.CartKey];
        }
    }
}