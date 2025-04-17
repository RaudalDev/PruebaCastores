using Inventarios.BusinessLayer;
using Inventarios.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventarios
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InicioSesion_Click(object sender, EventArgs e)
        {
            UsuariosBL usuariosBL = new UsuariosBL();
            UsuariosMod usuarioInfo = new UsuariosMod();

            usuarioInfo = usuariosBL.ValidaUsuario(txtUsuario.Value, txtPassword.Value);

            if (usuarioInfo.idUsuario != 0)
            {
                Session["IdUsuario"] = usuarioInfo.idUsuario;
                Session["nombreUsu"] = usuarioInfo.nombre;
                Session["IdRol"] = usuarioInfo.idRol;

                Response.RedirectPermanent("PaginaInicio.aspx");
            }
            else
            {
                Alerta.Visible = true;
            }
        }
    }
}