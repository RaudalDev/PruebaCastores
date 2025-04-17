using Inventarios.DataLayer;
using Inventarios.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Inventarios.BusinessLayer
{
    public class ProductosBL
    {
        public List<ProductosMod> obtenerProductos()
        {
            List<ProductosMod> lstProductosInfo = new List<ProductosMod>();
            ProductosDL productosDL = new ProductosDL();
            DataTable productosDataTable = new DataTable();

            productosDataTable = productosDL.obtenerProductos();

            if (productosDataTable.Rows.Count > 0)
            {
                foreach (DataRow row in productosDataTable.Rows)
                {
                    ProductosMod ProductoInfo = new ProductosMod();

                    ProductoInfo.idProducto = int.Parse(row["idProducto"].ToString());
                    ProductoInfo.nombre = row["nombre"].ToString();
                    ProductoInfo.cantidadExistencia = int.Parse(row["cantidadExistencia"].ToString());
                    ProductoInfo.estatus = int.Parse(row["estatus"].ToString());

                    if (ProductoInfo.estatus == 1)
                        ProductoInfo.descEstatus = "Activo";
                    else
                        ProductoInfo.descEstatus = "Inactivo";

                    lstProductosInfo.Add(ProductoInfo);
                }
            }
            else
            {
                ProductosMod ProductoInfo = new ProductosMod();

                ProductoInfo.idProducto = 0;
                ProductoInfo.cantidadExistencia = 0;
                ProductoInfo.nombre = "No Se Encontró Información";
                ProductoInfo.descEstatus = "N/A";

                lstProductosInfo.Add(ProductoInfo);
            }

            return lstProductosInfo;
        }

        public List<ProductosMod> obtenerProductosActivos()
        {
            List<ProductosMod> lstProductosInfo = new List<ProductosMod>();
            ProductosDL productosDL = new ProductosDL();
            DataTable productosDataTable = new DataTable();

            productosDataTable = productosDL.obtenerProductosActivos();

            if (productosDataTable.Rows.Count > 0)
            {
                foreach (DataRow row in productosDataTable.Rows)
                {
                    ProductosMod ProductoInfo = new ProductosMod();

                    ProductoInfo.idProducto = int.Parse(row["idProducto"].ToString());
                    ProductoInfo.nombre = row["nombre"].ToString();
                    ProductoInfo.cantidadExistencia = int.Parse(row["cantidadExistencia"].ToString());

                    lstProductosInfo.Add(ProductoInfo);
                }
            }
            else
            {
                ProductosMod ProductoInfo = new ProductosMod();

                ProductoInfo.idProducto = 0;
                ProductoInfo.cantidadExistencia = 0;
                ProductoInfo.nombre = "No Se Encontró Información";

                lstProductosInfo.Add(ProductoInfo);
            }

            return lstProductosInfo;
        }

        public int registrarProducto(string producto)
        {
            ProductosDL productosDL = new ProductosDL();
            int resultadoProceso = 0;
            DataTable productosDataTable = new DataTable();

            productosDataTable = productosDL.registrarProducto(producto);

            int Resultado = int.Parse(productosDataTable.Rows[0]["Resultado"].ToString());

            if (Resultado >= 1)
            {
                resultadoProceso = Resultado;
            }

            return resultadoProceso;
        }

        public int ingresarInventario(int idProducto, int Existencia)
        {
            ProductosDL productosDL = new ProductosDL();
            int resultadoProceso = 0;
            DataTable productosDataTable = new DataTable();

            productosDataTable = productosDL.ingresarInventario(idProducto, Existencia);

            int Resultado = int.Parse(productosDataTable.Rows[0]["Resultado"].ToString());

            if (Resultado >= 1)
            {
                resultadoProceso = Resultado;
            }

            return resultadoProceso;
        }

        public int salidaInventario(int idProducto, int Cantidad)
        {
            ProductosDL productosDL = new ProductosDL();
            int resultadoProceso = 0;
            DataTable productosDataTable = new DataTable();

            productosDataTable = productosDL.salidaInventario(idProducto, Cantidad);

            int Resultado = int.Parse(productosDataTable.Rows[0]["Resultado"].ToString());

            if (Resultado >= 1)
            {
                resultadoProceso = Resultado;
            }

            return resultadoProceso;
        }

        public int cambiarEstatusProducto(int idProducto, int estatus)
        {
            ProductosDL productosDL = new ProductosDL();
            int resultadoProceso = 0;
            DataTable productosDataTable = new DataTable();

            productosDataTable = productosDL.cambiarEstatusProducto(idProducto, estatus);

            int Resultado = int.Parse(productosDataTable.Rows[0]["Resultado"].ToString());

            if (Resultado >= 1)
            {
                resultadoProceso = Resultado;
            }

            return resultadoProceso;
        }
    }
}