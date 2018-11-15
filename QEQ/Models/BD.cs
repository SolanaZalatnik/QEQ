using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QEQ.Models
{
    public class BD
    {
        private static string conexion = "Server=10.128.8.16;Database=QEQB03;UID=QEQB03;PWD=QEQB03;";

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
        public static int InsertarPersonaje(Personajes x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_InsertarPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            Consulta.Parameters.AddWithValue("@pImagen", x.Imagen);
            Consulta.Parameters.AddWithValue("@pIDCategoria", x.IDCategoria);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static int ModificarPersonaje(Personajes x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_ModificarPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            Consulta.Parameters.AddWithValue("@pImagen", x.Imagen);
            Consulta.Parameters.AddWithValue("@pIDCategoria", x.IDCategoria);
            Consulta.Parameters.AddWithValue("@pID", x.IDPersonaje);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static int EliminarPersonaje(Personajes x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_EliminarPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pID", x.IDPersonaje);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static List<Personajes> ListarPersonajes()
        {
            List<Personajes> ListPersonajes = new List<Personajes>();
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_ListarPersonajes";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IDPersonaje = Convert.ToInt32(Lector["IDPersonaje"]);
                string Nombre = Lector["Nombre"].ToString();
                string Imagen = Lector["Imagen"].ToString();
                int IDCategoria = Convert.ToInt32(Lector["IDCategoria"]);
                Personajes p = new Personajes(IDPersonaje, Nombre, Imagen, IDCategoria, null);
                ListPersonajes.Add(p);
            }
            Desconectar(Coneccion);
            return ListPersonajes;
        }
        public static Personajes TraerPer(int IDPer)
        {
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_TraerPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pPersonaje", IDPer);
            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {

                int IDPersonaje = Convert.ToInt32(Lector["IDPersonaje"]);
                string Nombre = Lector["Nombre"].ToString();
                string Imagen = Lector["Imagen"].ToString();
                int IDCategoria = Convert.ToInt32(Lector["IDCategoria"]);
                Personajes Datos = new Personajes(IDPersonaje, Nombre, Imagen, IDCategoria, null);
                Desconectar(Coneccion);
                return Datos;
            }
            else
            {
                Desconectar(Coneccion);
                return null;
            }
        }

        public static bool LoginUs(string NombreUs, string Pass)
        {
            NombreUs = (NombreUs == null ? "" : NombreUs); //Es un if
            Pass = (Pass == null ? "" : Pass); //Es un if
            bool Correct = false;
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_Login";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pNombre", NombreUs);
            Consulta.Parameters.AddWithValue("@pContraseña", Pass);
            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {
                Correct = true;
            }
            Desconectar(Coneccion);
            return Correct;
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
        public static Usuarios TraerUs(string NombUsu)
        {
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_TraerUs";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pNombreUs", NombUsu);
            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {
                string NombUsuario = Lector["NombUsuario"].ToString();
                string Nombre = Lector["Nombre"].ToString();
                string Apellido = Lector["Apellido"].ToString();
                string Contraseña = Lector["Contraseña"].ToString();
                bool Administrador = Convert.ToBoolean(Lector["Administrador"]);
                int Puntaje = Convert.ToInt32(Lector["Puntaje"]);
                Usuarios Datos = new Usuarios(999, NombUsuario, Nombre, Apellido, Contraseña, Administrador, Puntaje);
                Desconectar(Coneccion);
                return Datos;
            }
            else
            {
                Desconectar(Coneccion);
                return null;
            }
		}
        public static List<Usuarios> ListarUsuarios()
        {
            List<Usuarios> LU = new List<Usuarios>();
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_ListarUsuarios";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader Lector = Consulta.ExecuteReader();
            while(Lector.Read())
            {
                int ID = Convert.ToInt32(Lector["IDUsuario"]);
                string NombUsuario = Lector["NombUsuario"].ToString();
                string Nombre = Lector["Nombre"].ToString();
                string Apellido = Lector["Apellido"].ToString();
                string Contraseña = Lector["Contraseña"].ToString();
                bool Administrador = Convert.ToBoolean(Lector["Administrador"]);
                int Puntaje = Convert.ToInt32(Lector["Puntaje"]);
                Usuarios Datos = new Usuarios(ID, NombUsuario, Nombre, Apellido, Contraseña, Administrador, Puntaje);
                LU.Add(Datos);
                
            }
            Desconectar(Coneccion);
                return LU;
        }
        public static List<Preguntas> ListarPreguntas()
        {
            List<Preguntas> LP = new List<Preguntas>();
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_ListarPreguntas";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int ID = Convert.ToInt32(Lector["IDPregunta"]);
                string Preg = Lector["Pregunta"].ToString();
           
                Preguntas Datos = new Preguntas(ID,Preg);
                LP.Add(Datos);

            }
            Desconectar(Coneccion);
            return LP;
        }
        public static List<Categorias> ListarCategorias()
        {
            List<Categorias> LC = new List<Categorias>();
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_ListarCategorias";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int ID = Convert.ToInt32(Lector["IDCategoria"]);
                string Cat = Lector["Categoria"].ToString();

                Categorias Datos = new Categorias(ID, Cat);
                LC.Add(Datos);

            }
            Desconectar(Coneccion);
            return LC;
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
            Consulta.Parameters.AddWithValue("@pAdministrar", x.Administrador);
            Consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static int ModificarPregunta(Preguntas x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_ModificarPregunta";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pPregunta", x.Pregunta);
            Consulta.Parameters.AddWithValue("@ID", x.IDPregunta);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static int ModificarCategoria(Categorias x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_ModificarCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pCategoria", x.Categoria);
            Consulta.Parameters.AddWithValue("@ID", x.IDCategoria);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }

        public static int InsertarPregunta(Preguntas x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_InsertarPregunta";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pPregunta", x.Pregunta);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static int InsertarCategoria(Categorias x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_InsertarCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pCategoria", x.Categoria);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static int EliminarPregunta(int ID)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_EliminarPregunta";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pID", ID);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static int EliminarCategoria(int ID)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "sp_EliminarCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pID", ID);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static Preguntas TraerPregunta(int IDPreg)
        {
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_TraerPregunta";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pID", IDPreg);
            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {
                string Preg = Lector["Pregunta"].ToString();
                int ID = Convert.ToInt32(Lector["IDPregunta"]);
                Preguntas Datos = new Preguntas(ID, Preg);
                Desconectar(Coneccion);
                return Datos;
            }
            else
            {
                Desconectar(Coneccion);
                return null;
            }
        }
        public static Categorias TraerCategoria(int ID)
        {
            SqlConnection Coneccion = Conectar();
            SqlCommand Consulta = Coneccion.CreateCommand();
            Consulta.CommandText = "sp_TraerCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pCategoria", ID);
            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {
                string Cat = Lector["Categoria"].ToString();
                int IDC = Convert.ToInt32(Lector["IDCategoria"]);
                Categorias Datos = new Categorias(IDC, Cat);
                Desconectar(Coneccion);
                return Datos;
            }
            else
            {
                Desconectar(Coneccion);
                return null;
            }
        }
    }
}