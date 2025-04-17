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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                string Nombre = Session["nombreUsu"].ToString();
                int Rol = int.Parse(Session["IdRol"].ToString());

                int numProd = int.Parse(Request.QueryString["nmpdt"]);
                string nomProd = Request.QueryString["nbrpdt"];
                int cantProd = int.Parse(Request.QueryString["ctdpdt"]);

                MostrarOpcionesRol(Rol, numProd, nomProd, cantProd);
            }
        }

        private void MostrarOpcionesRol(int idRol, int numProd, string nomProd, int cantProd)
        {
            switch (idRol)
            {
                case 1:
                    AgregarExist.Visible = true;
                    BotonesAgregarExist.Visible = true;
                    llenarInfoAdm(numProd, nomProd, cantProd);
                    break;
                case 2:
                    RegistrarSalidas.Visible = true;
                    BotonesRegistrarSalida.Visible = true;
                    llenarInfoAlm(numProd, nomProd, cantProd);
                    break;
            }
        }

        private void llenarInfoAdm(int numProd, string nomProd, int cantProd)
        {
            txtNoProd.Value = numProd.ToString();
            txtProducto.Value = nomProd.ToString();
            txtExistenciasAct.Value = cantProd.ToString();
        }

        private void llenarInfoAlm(int numProd, string nomProd, int cantProd)
        {
            txtNoProd.Value = numProd.ToString();
            txtProducto.Value = nomProd.ToString();
            txtExistenciasActualesS.Value = cantProd.ToString();
        }

        protected void btnAgregarExistencias_Click(object sender, EventArgs e)
        {
            ProductosBL productosBL = new ProductosBL();
            int sumatotal = 0;
            int resultado = 0;

            sumatotal = int.Parse(txtExistenciasAct.Value) + int.Parse(txtCantidadAgr.Value);

            if (int.Parse(txtExistenciasAct.Value) < sumatotal)
            {
                resultado = productosBL.ingresarInventario(int.Parse(txtNoProd.Value), sumatotal);

                if (resultado >= 1)
                {
                    int result = 0;

                    result = RegistrarHistorial(1);

                    if (result >= 1)
                        Response.RedirectPermanent("Inventario.aspx?rstprd=1");
                    else
                        Response.RedirectPermanent("Inventario.aspx?rstprd=2");
                }
                else
                    Response.RedirectPermanent("Inventario.aspx?rstprd=2");
            }
            else
                Util.UtilControls.SweetBox("Atencion!", "Desde Este Modulo No Puedes Reducir El Inventario", "warning", this.Page, this.GetType());
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.RedirectPermanent("Inventario.aspx?rstprd=0");
        }

        protected void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            ProductosBL productosBL = new ProductosBL();
            int restaTotal = 0;
            int resultado = 0;

            restaTotal = int.Parse(txtExistenciasActualesS.Value) - int.Parse(txtCantidadSalida.Value);

            if (int.Parse(txtExistenciasActualesS.Value) > restaTotal)
            {
                resultado = productosBL.salidaInventario(int.Parse(txtNoProd.Value), int.Parse(txtCantidadSalida.Value));

                if (resultado >= 1)
                {
                    int result = 0;

                    result = RegistrarHistorial(2);

                    if (result >= 1)
                        Response.RedirectPermanent("Inventario.aspx?rstprd=1");
                    else
                        Response.RedirectPermanent("Inventario.aspx?rstprd=2");
                }
                else
                    Response.RedirectPermanent("Inventario.aspx?rstprd=2");
            }
            else
                Util.UtilControls.SweetBox("Atencion!", "Desde Este Modulo No Puedes Ingresar Existencias En El Inventario", "warning", this.Page, this.GetType());
        }

        protected void btnVolverEnt_Click(object sender, EventArgs e)
        {
            Response.RedirectPermanent("Inventario.aspx?rstprd=0");
        }

        private int RegistrarHistorial(int tipoMov)
        {
            int resultado = 0;
            HistorialBL historialBL = new HistorialBL();
            HistorialMod historialInf = new HistorialMod();

            if (tipoMov == 1)
            {
                historialInf.descripcion = "Se registro una entrada de " + int.Parse(txtCantidadAgr.Value) + " Piezas";
                historialInf.tipoMovimiento = 1;
            }
            else
            {
                historialInf.descripcion = "Se registro una salida de " + int.Parse(txtCantidadSalida.Value) + " Piezas";
                historialInf.tipoMovimiento = 2;
            }

            historialInf.idUsuario = int.Parse(Session["IdUsuario"].ToString());
            historialInf.idProducto = int.Parse(txtNoProd.Value.ToString());
            historialInf.fechaMovimiento = DateTime.Now;

            resultado = historialBL.Insertarhistorial(historialInf);

            return resultado;
        }
    }
}