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
    public partial class Historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                string Nombre = Session["nombreUsu"].ToString();
                int Rol = int.Parse(Session["IdRol"].ToString());

                llenarGrid(0);
            }
        }

        private void llenarGrid(int TipoMov)
        {
            HistorialBL historialBL = new HistorialBL();
            List<HistorialMod> historialInfo = new List<HistorialMod>();

            historialInfo = historialBL.obtenerHistorial(TipoMov);

            grvHistorial.DataSource = historialInfo;
            grvHistorial.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rdbTodos.Checked)
                llenarGrid(0);
            else if (rdbEntradas.Checked)
                llenarGrid(1);
            else
                llenarGrid(2);
        }
    }
}