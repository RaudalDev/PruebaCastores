using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Inventarios.DataLayer
{
    public class ProductosDL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();

        public DataTable obtenerProductos()
        {
            var connection = new SqlConnection(connectionString);
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("sP_Inventario_Productos_Obt", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    dtUsuarios.Load(dr);
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dtUsuarios;
        }

        public DataTable obtenerProductosActivos()
        {
            var connection = new SqlConnection(connectionString);
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("sP_Inventario_ProductosActivos_Obt", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    dtUsuarios.Load(dr);
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dtUsuarios;
        }

        public DataTable registrarProducto(string producto)
        {
            var connection = new SqlConnection(connectionString);
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("sP_Inventario_Productos_Ins", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", producto);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dtUsuarios.Load(dr);
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dtUsuarios;
        }

        public DataTable ingresarInventario(int idProducto, int Existencia)
        {
            var connection = new SqlConnection(connectionString);
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("sP_Inventario_AumentarProductos_Act", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@Existencias", Existencia);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dtUsuarios.Load(dr);
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dtUsuarios;
        }

        public DataTable salidaInventario(int idProducto, int Cantidad)
        {
            var connection = new SqlConnection(connectionString);
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("sP_Inventario_RestarProductos_Act", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@cantidadRestada", Cantidad);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dtUsuarios.Load(dr);
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dtUsuarios;
        }

        public DataTable cambiarEstatusProducto(int idProducto, int estatus)
        {
            var connection = new SqlConnection(connectionString);
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("sP_Inventario_EstatusProductos_Act", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@estatus", estatus);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dtUsuarios.Load(dr);
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dtUsuarios;
        }
    }
}