using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjidrezRestaurant.ET;
using AjidrezRestaurant.BL;

namespace AjidrezRestaurant.Controllers
{
    public class PlatosCartaController : Controller
    {
        public ActionResult Carta()
        {
            return View();
        }
    }
}