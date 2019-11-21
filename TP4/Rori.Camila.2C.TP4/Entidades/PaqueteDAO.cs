using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            string connectionString = @"Server = .\SQLEXPRESS ; Database = correo-sp-2017 ; Trusted_Connection = true;";
            conexion = new SqlConnection(connectionString);
            comando = new SqlCommand();
            comando.Connection = conexion; 
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.Add("@direccionEntrega");
            comando.Parameters.Add("@trackingID");
            comando.Parameters.AddWithValue("@alumno", "Camila Rori");

        }
        public static bool Insertar(Paquete p)
        {
            try
            {
                conexion.Open();    
                string comandoString = "INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES (@direccionEntrega, @trackingID, @alumno);";
                
                comando.Parameters["@direccionEntrega"].Value = p.DireccionEntrega;
                comando.Parameters["@trackingID"].Value = p.TrackingID;
                comando.CommandText = comandoString;
                comando.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

            }
            return true;

        }
    }
}

/*
 * A. De surgir cualquier error con la carga de datos, se deberá lanzar una excepción tantas veces como sea
necesario hasta llegar a la vista (formulario). A través de un MessageBox informar lo ocurrido al
usuario de forma clara. De ser necesario, utilizar un evento para este fin.
B. El campo alumno de la base de datos deberá contener el nombre del alumno que está realizando el
TP.

    */