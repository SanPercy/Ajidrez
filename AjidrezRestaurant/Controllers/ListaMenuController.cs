using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjidrezRestaurant.Controllers
{
    public class ListaMenuController : Controller
    {
        // GET: ListaMenu
        public ActionResult Menu()
        {
            return View();
        }
    }
}