using PubNew.DAL;
using PubNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PubNew.Controllers
{
    public class ShoppingCartController : Controller
    {
        PubContext db = new PubContext();
        // GET: ShoppingCart
        public ActionResult ShoppingCartView()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the Item from the database
            var addedItem = db.Items
                .Single(Item => Item.ItemID == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedItem);

            // Go back to the main store page for more shopping
            return RedirectToAction("ShoppingCartView");
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the Item to display confirmation
            string ItemName = db.Carts
                .Single(item => item.RecordId == id).Item.ItemName;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(ItemName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        //show item list
        public ActionResult ItemList(String searchString)
        {
            var items = from s in db.Items
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                
              items = items.Where(s => s.Category.Contains(searchString) && s.isAvailable != true  );
            }
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult ItemDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

    }
}