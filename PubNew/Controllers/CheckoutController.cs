using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using PubNew.DAL;
using PubNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PubNew.App_Start.IdentityConfig;
using System.Net;

namespace PubNew.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        PubContext db = new PubContext();
        const string PromoCode = "FREE";

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            private set => _signInManager = value;
        }
        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        //GET: Checkout
        public ActionResult Checkout()
        {
            return View();
        }

        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult Checkout(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    

                    User user = UserManager.FindByName(User.Identity.Name);
                    order.UserID = user.Id;
                    order.CreatDate = DateTime.Now;
                    order.TotalPrice = cart.GetTotal();
                    order.Stauts = "done";
                    //Save Order
                    db.Orders.Add(order);
                    db.SaveChanges();
                    //Process the order
                    cart.CreateOrder(order);
                    return RedirectToAction("Complete",
                        new { id = order.OrderID });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            String name = SignInManager.GetVerifiedUserId();

            bool isValid = db.Orders.Any(
                o => o.OrderID == id &&
                o.UserID.Equals(name) );

            Order order = db.Orders.Find(id);

                return View(order);

        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
    }