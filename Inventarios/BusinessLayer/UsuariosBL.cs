using Inventarios.DataLayer;
using Inventarios.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Inventarios.BusinessLayer
{
    public class UsuariosBL
    {
        public UsuariosMod ValidaUsuario(string Usuario, string Password)
        {
            UsuariosMod usuarioInfo = new UsuariosMod();
            UsuariosDL usuariosDL = new UsuariosDL();
            DataTable usuariosDataTable = new DataTable();

            usuariosDataTable = usuariosDL.ValidarUsuario(Usuario, Password);

            if (usuariosDataTable.Rows.Count > 0)
            {
                usuarioInfo.idUsuario = int.Parse(usuariosDataTable.Rows[0]["idUsuario"].ToString());
                usuarioInfo.nombre = usuariosDataTable.Rows[0]["nombre"].ToString();
                usuarioInfo.idRol = int.Parse(usuariosDataTable.Rows[0]["idRol"].ToString());
            }

            return usuarioInfo;
        }
    }
}