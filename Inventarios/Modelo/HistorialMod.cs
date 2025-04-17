using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventarios.Modelo
{
    public class HistorialMod
    {
        public int idHistorial { get; set; }
        public string descripcion { get; set; }
        public int tipoMovimiento { get; set; }
        public string movimiento { get; set; }
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public int idProducto { get; set; }
        public string producto { get; set; }
        public DateTime fechaMovimiento { get; set; }
    }
}