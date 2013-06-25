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
            return new CartModel
                {
                    CartItems = GetCartFromSession().Select(kp => kp.Value)
                };
        }

        private static Dictionary<int, CartItem> GetCartFromSession()
        {
            var session = HttpContext.Current.Session;
            session[CartKey] = session[CartKey] ?? new Dictionary<int, CartItem>();
            return (Dictionary<int, CartItem>)session[CartKey];
        }
    }
}