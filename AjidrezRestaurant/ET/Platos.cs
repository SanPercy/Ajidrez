using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjidrezRestaurant.ET;

namespace AjidrezRestaurant.ET
{
    public class Platos
    {
        public int IdProducto { get; set; }
        public double Precio { get; set; }
        public int IdClase { get; set; }
        public string Estado { get; set; }
        public string NombreProducto { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }

        public Clase Clase { get; set; }

        public Platos()
        {
            Clase = new Clase();
        }

    }
}