using Inventarios.BusinessLayer;
using Inventarios.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventarios
{
    public partial class Inventario1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                string Nombre = Session["nombreUsu"].ToString();
                int Rol = int.Parse(Session["IdRol"].ToString());

                int resultDevuelto = int.Parse(Request.QueryString["rstprd"]);

                if (resultDevuelto == 1)
                    Util.UtilControls.SweetBox("OK!", "Las Existencias Para El Producto Se Actualizo Correctamente", "success", this.Page, this.GetType());
                else if (resultDevuelto == 2)
                    Util.UtilControls.SweetBox("Atencion!", "Ocurrió Un Error. Intenta de Nuevo O Contacta Al Administrador.", "warning", this.Page, this.GetType());

                MostrarOpcionesRol(Rol);
            }
        }

        private void MostrarOpcionesRol(int idRol)
        {
            switch (idRol)
            {
                case 1:
                    grvInventarioAdmin.Visible = true;
                    BotonAltaProd.Visible = true;
                    llenarGridAdmin();
                    break;
                case 2:
                    grvInventarioAlmas.Visible = true;
                    llenarGridAlmasenista();
                    break;
            }
        }

        private void llenarGridAdmin()
        {
            ProductosBL historialSolicitudesBL = new ProductosBL();
            List<ProductosMod> lstHistorialEmpleadoInfo = new List<ProductosMod>();

            lstHistorialEmpleadoInfo = historialSolicitudesBL.obtenerProductos();

            grvInventarioAdmin.DataSource = lstHistorialEmpleadoInfo;
            grvInventarioAdmin.DataBind();
        }

        private void llenarGridAlmasenista()
        {
            ProductosBL historialSolicitudesBL = new ProductosBL();
            List<ProductosMod> lstHistorialEmpleadoInfo = new List<ProductosMod>();

            lstHistorialEmpleadoInfo = historialSolicitudesBL.obtenerProductosActivos();

            grvInventarioAlmas.DataSource = lstHistorialEmpleadoInfo;
            grvInventarioAlmas.DataBind();
        }

        protected void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            ProductosBL productosBL = new ProductosBL();
            int resultado = 0;
            string nombreProducto = string.Empty;

            nombreProducto = txtNombreProducto.Value.ToString();

            resultado = productosBL.registrarProducto(nombreProducto);

            if (resultado >= 1)
            {
                int result = 0;

                result = RegistrarHistorial(1, resultado);
                if (result == 1)
                {
                    Util.UtilControls.SweetBox("OK!", "El Producto Se Registró Correctamente Con Numero" + resultado, "success", this.Page, this.GetType());
                    llenarGridAdmin();
                }
                else
                    Util.UtilControls.SweetBox("Atencion!", "Ocurrió Un Error. Intenta de Nuevo O Contacta Al Administrador.", "warning", this.Page, this.GetType());
            }
            else
                Util.UtilControls.SweetBox("Atencion!", "Ocurrió Un Error. Intenta de Nuevo O Contacta Al Administrador.", "warning", this.Page, this.GetType());
        }

        protected void grvInventarioAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable infoGridDT = new DataTable();

            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());

                if (grvInventarioAdmin.HeaderRow != null)
                {

                    for (int i = 0; i < grvInventarioAdmin.HeaderRow.Cells.Count; i++)
                    {
                        var columna = grvInventarioAdmin.HeaderRow.Cells[i].Text;
                        infoGridDT.Columns.Add(columna);
                    }
                }

                foreach (GridViewRow row in grvInventarioAdmin.Rows)
                {
                    DataRow dr;
                    dr = infoGridDT.NewRow();

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dr[i] = row.Cells[i].Text;
                    }
                    infoGridDT.Rows.Add(dr);
                }

                int numProduto = int.Parse(infoGridDT.Rows[index]["Num. Producto"].ToString());
                string nomProduto = infoGridDT.Rows[index]["Producto"].ToString();
                int cantProduto = int.Parse(infoGridDT.Rows[index]["Existencias (Pzs)"].ToString());
                string estProduto = infoGridDT.Rows[index]["Estatus"].ToString();

                if (estProduto.Equals("Activo"))
                {
                    if (numProduto != 0)
                        Response.Redirect("DetalleProducto.aspx?nmpdt=" + numProduto + "&ctdpdt=" + cantProduto + "&nbrpdt=" + nomProduto);
                }
                else
                    Util.UtilControls.SweetBox("Atencion!", "No Puedes Agregar Existencias A Un Producto Inactivo", "warning", this.Page, this.GetType());
            }
            else if (e.CommandName == "Edit")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                ProductosBL productosBL = new ProductosBL();
                int resultado = 0;

                if (grvInventarioAdmin.HeaderRow != null)
                {

                    for (int i = 0; i < grvInventarioAdmin.HeaderRow.Cells.Count; i++)
                    {
                        var columna = grvInventarioAdmin.HeaderRow.Cells[i].Text;
                        infoGridDT.Columns.Add(columna);
                    }
                }

                foreach (GridViewRow row in grvInventarioAdmin.Rows)
                {
                    DataRow dr;
                    dr = infoGridDT.NewRow();

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dr[i] = row.Cells[i].Text;
                    }
                    infoGridDT.Rows.Add(dr);
                }

                int numProduto = int.Parse(infoGridDT.Rows[index]["Num. Producto"].ToString());
                int cantProduto = int.Parse(infoGridDT.Rows[index]["Existencias (Pzs)"].ToString());
                string estProduto = infoGridDT.Rows[index]["Estatus"].ToString();

                if (cantProduto == 0 && estProduto.Equals("Activo"))
                {
                    if (estProduto.Equals("Activo"))
                        resultado = productosBL.cambiarEstatusProducto(numProduto, 2);
                    else
                        resultado = productosBL.cambiarEstatusProducto(numProduto, 1);


                    if (resultado >= 1)
                    {
                        Util.UtilControls.SweetBox("OK!", "El Estatus Del Producto Se Realizo Correctamente", "success", this.Page, this.GetType());
                        llenarGridAdmin();
                    }
                    else
                        Util.UtilControls.SweetBox("Atencion!", "Ocurrió Un Error. Intenta de Nuevo O Contacta Al Administrador.", "warning", this.Page, this.GetType());
                }
                else
                    Util.UtilControls.SweetBox("Atencion!", "No Puedes Inavilitar Un Producto que cuente con existencias.", "warning", this.Page, this.GetType());
            }
        }

        protected void grvInventarioAlmas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable infoGridDT = new DataTable();

            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());

                if (grvInventarioAlmas.HeaderRow != null)
                {

                    for (int i = 0; i < grvInventarioAlmas.HeaderRow.Cells.Count; i++)
                    {
                        var columna = grvInventarioAlmas.HeaderRow.Cells[i].Text;
                        infoGridDT.Columns.Add(columna);
                    }
                }

                foreach (GridViewRow row in grvInventarioAlmas.Rows)
                {
                    DataRow dr;
                    dr = infoGridDT.NewRow();

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dr[i] = row.Cells[i].Text;
                    }
                    infoGridDT.Rows.Add(dr);
                }

                int numProduto = int.Parse(infoGridDT.Rows[index]["Num. Producto"].ToString());
                string nomProduto = infoGridDT.Rows[index]["Producto"].ToString();
                int cantProduto = int.Parse(infoGridDT.Rows[index]["Existencias (Pzs)"].ToString());

                if (cantProduto > 0)
                {
                    if (numProduto != 0)
                        Response.Redirect("DetalleProducto.aspx?nmpdt=" + numProduto + "&nbrpdt=" + nomProduto + "&ctdpdt=" + cantProduto);
                }
                else
                    Util.UtilControls.SweetBox("Atencion!", "No Puedes Dar Salida De Producto Ya Que No Cuentas Con Existencias", "warning", this.Page, this.GetType());
            }
        }

        protected void grvInventarioAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        private int RegistrarHistorial(int tipoMov, int noProducto)
        {
            int resultado = 0;
            HistorialBL historialBL = new HistorialBL();
            HistorialMod historialInf = new HistorialMod();

            historialInf.descripcion = "Alta de producto con Numero " + noProducto;
            historialInf.tipoMovimiento = 1;
            historialInf.idUsuario = int.Parse(Session["IdUsuario"].ToString());
            historialInf.idProducto = noProducto;
            historialInf.fechaMovimiento = DateTime.Now;

            resultado = historialBL.Insertarhistorial(historialInf);

            return resultado;
        }
    }
}