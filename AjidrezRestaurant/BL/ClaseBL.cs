using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjidrezRestaurant.DAL;
using AjidrezRestaurant.ET;


namespace AjidrezRestaurant.BL
{
    public class ClaseBL
    {

        private ClaseDAL claseDAL = new ClaseDAL();

        public List<Clase> Listar()
        {
            return claseDAL.Listar();
        }

        public Clase Obtener(int id)
        {
            return claseDAL.Obtener(id);
        }

        public bool Actualizar(Clase clase)
        {
            return claseDAL.Actualizar(clase);
        }

        public bool Registrar(Clase clase)
        {
            return claseDAL.Registrar(clase);
        }

        public bool Eliminar(int id)
        {
            return claseDAL.Eliminar(id);
        }

    }
}