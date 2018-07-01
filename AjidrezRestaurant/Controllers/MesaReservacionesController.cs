using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjidrezRestaurant.Controllers
{
    public class MesaReservacionesController : Controller
    {
        // GET: MesaReservaciones
        public ActionResult Reservaciones()
        {
            return View();
        }
    }
}