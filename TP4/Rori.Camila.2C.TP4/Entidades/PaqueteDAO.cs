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
            comando.Parameters.Add("@direccionEntrega", System.Data.SqlDbType.VarChar);
            comando.Parameters.Add("@trackingID", System.Data.SqlDbType.VarChar);
            comando.Parameters.AddWithValue("@alumno", "Camila Rori");

        }

        /// <summary>
        /// Guarda un objeto del tipo Paquete en una base de datos
        /// </summary>
        /// <param name="p">Objeto a guardar</param>
        /// <returns></returns>
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
