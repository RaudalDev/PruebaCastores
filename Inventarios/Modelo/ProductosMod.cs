using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventarios.Modelo
{
    public class ProductosMod
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public int cantidadExistencia { get; set; }
        public int estatus { get; set; }
        public string descEstatus { get; set; }
    }
}