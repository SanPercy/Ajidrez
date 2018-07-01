using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjidrezRestaurant.DAL;
using AjidrezRestaurant.ET;


namespace AjidrezRestaurant.BL
{
    public class PlatosBL
    {
        private PlatosDAL x = new PlatosDAL();

        public List<Platos> Listar()
        {
            return x.Listar();
        }

        public Platos Obtener(int id)
        {
            return x.Obtener(id);
        }

        public bool Actualizar(Platos y)
        {
            return x.Actualizar(y);
        }

        public bool Registrar(Platos y)
        {
            return x.Registrar(y);
        }

        public bool Eliminar(int id)
        {
            return x.Eliminar(id);
        }

    }
}