using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models.ViewModels;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        MVCMusicStoreDB dbContext = new MVCMusicStoreDB();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            ShoppingCartViewModel vm = new ShoppingCartViewModel()
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetCartTotal()
            };
            return View(vm);
        }

        

        // GET: /ShoppingCart/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            //id is AlbumId
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        // POST: Ajax Call
        public ActionResult RemoveFromCart(int id)
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            string albumTitle = dbContext.Carts.SingleOrDefault(c =>c.RecordId == id).AlbumSelected.Title;
            int itemCnt = cart.RemoveFromCart(id);

            ShoppingCartRemoveViewModel vm = new ShoppingCartRemoveViewModel()
            {
                ItemCount = itemCnt,
                DeleteId = id,
                CartTotal = cart.GetCartTotal(),
                Message = albumTitle + " has been removed from the cart."
            };

            return Json(vm);
        }
    }
}