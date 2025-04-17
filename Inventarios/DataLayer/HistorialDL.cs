using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using Inventarios.Modelo;

namespace Inventarios.DataLayer
{
    public class HistorialDL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();

        public DataTable obtenerHistorial(int tipoMovimiento)
        {
            var connection = new SqlConnection(connectionString);
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("sP_Inventario_Historial_Obt", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tipoMovimiento", tipoMovimiento);

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

        public DataTable Insertarhistorial(HistorialMod historialInfo)
        {
            var connection = new SqlConnection(connectionString);
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("sP_Inventario_Historial_Ins", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@descripcion", historialInfo.descripcion);
                    cmd.Parameters.AddWithValue("@tipoMovimiento", historialInfo.tipoMovimiento);
                    cmd.Parameters.AddWithValue("@idUsuario", historialInfo.idUsuario);
                    cmd.Parameters.AddWithValue("@idProducto", historialInfo.idProducto);
                    cmd.Parameters.AddWithValue("@fechaMovimiento", historialInfo.fechaMovimiento);

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