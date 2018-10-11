using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QEQ.Models
{
    public class BD
    {
        private static string conexion = "Server=10.128.8.16;Database=QEQB03;Trusted_Connection=True;UID=QEQB03;PWD=QEQB03;";
        private static SqlConnection Conectar()
        {
            SqlConnection conector = new SqlConnection(conexion);
            conector.Open();
            return conector;
        }
        private static void Desconectar(SqlConnection conector)
        {
            conector.Close();
        }
        public static bool LoginUs(string NombreUs, string Pass)
        {
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_Login";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pNombre", NombreUs);
            Consulta.Parameters.AddWithValue("@pContraseña", Pass);
            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {
                Desconectar(Coneccion);
                return true;
            }
            else
            {
                Desconectar(Coneccion);
                return false;
            }
        }
        public static int InsertarUsuario(Usuarios x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_InsertarUsuario";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pNombUsuario", x.NombUsuario);
            Consulta.Parameters.AddWithValue("@pApellido", x.Apellido);
            Consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            Consulta.Parameters.AddWithValue("@pAdministrador", x.Administrador);
            Consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static string BuscarUsuario(string nom)
        {
            string NombreUsuario = "";
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_BuscarUsuario";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pUsuario", nom);
            SqlDataReader DataReader = Consulta.ExecuteReader();
            if (DataReader.Read())
            {
                NombreUsuario = (DataReader["NombUsuario"]).ToString();

            }
            Desconectar(Conexion);
            return NombreUsuario;
        }
        public static int ModificarUsuario(Usuarios x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_ModificarUsuario";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pNombUsuario", x.NombUsuario);
            Consulta.Parameters.AddWithValue("@pApellido", x.Apellido);
            Consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            Consulta.Parameters.AddWithValue("@pAdministrador", x.Administrador);
            Consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
    }
}