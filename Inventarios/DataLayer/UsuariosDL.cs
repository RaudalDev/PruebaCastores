using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Inventarios.DataLayer
{
    public class UsuariosDL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();
        public DataTable ValidarUsuario(string Usuario, string Contraseña)
        {
            var connection = new SqlConnection(connectionString);
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("sP_Inventario_ValidarUsuarios_Obt", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@correoUsuario", Usuario);
                    cmd.Parameters.AddWithValue("@contraseñaUsuario", Contraseña);

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