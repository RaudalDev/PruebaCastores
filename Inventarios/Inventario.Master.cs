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
    public partial class Inventario : System.Web.UI.MasterPage
    {
        public static long IdEmpleado = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int SesCou = Session.Count;

            if (SesCou > 0)
            {
                if (Session["IdUsuario"].ToString() == "NoUser")
                {
                    Response.RedirectPermanent("Default.aspx");
                }
            }
            else
            {
                Response.RedirectPermanent("Default.aspx");
            }

            if (!IsPostBack)
            {
                var Id = int.Parse(Session["IdUsuario"].ToString());
                string Nombre = Session["nombreUsu"].ToString();
                int Rol = int.Parse(Session["IdRol"].ToString());

                UsuariosBL usuariosBL = new UsuariosBL();
                UsuariosMod usuarioInfo = new UsuariosMod();

                IdEmpleado = Id;

                OrganizarMenu(Rol);
                AsignarRutas(Id);
                MarcarMenuSeleccionado(Nombre);
            }
        }

        private void OrganizarMenu(int NombreRol)
        {
            switch (NombreRol)
            {
                case 1:
                    InventarioMod.Visible = true;
                    HistorialMod.Visible = true;
                    break;
                case 2:
                    InventarioMod.Visible = true;
                    break;
            }
        }

        private void AsignarRutas(int Id_Usuario)
        {
            //Menu Inicio
            aMenuInicioMod.Attributes["href"] = "../PaginaInicio.aspx";
            //Inventario Modulo
            aInventarioMod.Attributes["href"] = "../Inventario.aspx?rstprd=0";
            //Historial De Inventario
            aHistorialMod.Attributes["href"] = "../Historial.aspx";
        }

        protected void MarcarMenuSeleccionado(string NombreEmpleado)
        {
            string paginaActual = Request.Path;

            EtiquetaEmpleadoMod.InnerText = NombreEmpleado;

            switch (paginaActual)
            {
                case "/PaginaInicio":
                    aMenuInicioMod.Attributes["class"] = "text-white text-bold";
                    EtiquetaIni.InnerText = "Inicio - " + NombreEmpleado;
                    break;
                case "/Inventario":
                    aInventarioMod.Attributes["class"] = "text-white text-bold";
                    EtiquetaIni.InnerText = "Inventario - " + NombreEmpleado;
                    break;
                case "/Historial":
                    aHistorialMod.Attributes["class"] = "text-white text-bold";
                    EtiquetaIni.InnerText = "Historial - " + NombreEmpleado;
                    break;
            }
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.RedirectPermanent("Default.aspx");
        }
    }
}