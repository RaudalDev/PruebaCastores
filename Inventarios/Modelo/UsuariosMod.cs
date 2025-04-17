using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventarios.Modelo
{
    public class UsuariosMod
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public int idRol { get; set; }
        public int estatus { get; set; }
    }
}