using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId;
        private const string CartSessionKey = "CartId";

        MVCMusicStoreDB db = new MVCMusicStoreDB();

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public string GetCartId(HttpContextBase context)
        {
            string cartId;
            
            if (context.Session[CartSessionKey] == null)
            {
                //Create a cart id and add it to the session variable
                cartId = Guid.NewGuid().ToString();
                context.Session[CartSessionKey] = cartId;
            }
            else
            {
                //retrive CartId
                cartId = context.Session[CartSessionKey].ToString();
            }
            return cartId;
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public decimal GetCartTotal()
        {
            decimal? total = (from CartItems in db.Carts
                             where CartItems.CartId == ShoppingCartId
                             select CartItems.AlbumSelected.Price * (int?) CartItems.Count).Sum();
            return total?? decimal.Zero;
        }

        public void AddToCart(int id)
        {
            
            //CartItem does not exist in db. add to db

            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.AlbumId == id);
            
            if (cartItem == null)
            {
                Album album = db.Albums.SingleOrDefault(a => a.AlbumId == id);
                cartItem = new Cart() {
                    CartId = ShoppingCartId,
                    AlbumId = id,
                    AlbumSelected = album,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                db.Carts.Add(cartItem);
            }
            else  
            {
                //CartItem exists already in db. update count
                cartItem.Count++;
            }
            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            Cart cartItem = db.Carts.SingleOrDefault(cart => cart.RecordId == id);
            int count = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    count = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }
                db.SaveChanges();
            }

            return count;
        }
    }
}