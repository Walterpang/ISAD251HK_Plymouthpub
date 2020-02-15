using PubNew.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PubNew.Controllers
{
    public class MenuController : Controller
    {
        PubContext db = new PubContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Store/Browse
        public string Browse()
        {
            return "Hello from Store.Browse()";
        }
        //
        // GET: /Store/Details
        public string Details()
        {
            return "Hello from Store.Details()";
        }

        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var itemsmenu = db.Items.ToList();
            return PartialView(itemsmenu);
        }

        public ActionResult FoodMenu(string Category)
        {
            var items = from s in db.Items
                        select s;
            if (!String.IsNullOrEmpty(Category))
            {

                items = items.Where(s => s.Category.Contains(Category) && s.isAvailable == true);
            }
            return View(items.ToList());
        }
    }
}