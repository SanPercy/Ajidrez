using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjidrezRestaurant.ET;
using AjidrezRestaurant.BL;

namespace AjidrezRestaurant.Controllers
{
    public class ManPlatosController : Controller
    {
        // GET: ManMenu
        private PlatosBL platosBL = new PlatosBL();
        private ClaseBL claseBL = new ClaseBL();

        public ActionResult Listar()
        {
            return View(platosBL.Listar());
        }

        public ActionResult Detalles(int id)
        {

            return View(platosBL.Obtener(id));

        }

        public ActionResult Crear(Platos plato)
        {
            ViewBag.Clases = claseBL.Listar();
            return View(plato);
        }

        public ActionResult Editar(int id = 0)
        {
            ViewBag.Clases = claseBL.Listar();
            return View(platosBL.Obtener(id));
        }

        [HttpPost]
        public ActionResult Registrar(Platos platos)
        {
            platosBL.Registrar(platos);
            return Redirect("~/PlatosCarta/Listar");
        }

        [HttpPost]
        public ActionResult Actualizar(Platos platos)
        {
            platosBL.Actualizar(platos);
            ViewBag.Mensaje = "Actualizado";
            return Redirect("~/PlatosCarta/Listar");
        }

        public ActionResult Eliminar(int id)
        {
            var r = platosBL.Eliminar(id);

            if (!r)
            {
                // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensaje.cshtml");
            }

            return Redirect("~/PlatosCarta/Listar");
        }
    }
}