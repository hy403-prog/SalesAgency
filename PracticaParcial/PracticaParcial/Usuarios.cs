using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial
{
    public class Usuarios
    {
        public int idUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }

        public Usuarios(string _Usuario, string _Contrasenia)
        {
            Usuario= _Usuario;
            Contrasenia= _Contrasenia;
        }

        public Usuarios()
        {
            
        }

        public bool login(string usuario, string contrasenia)
        {
            string nombreUsuario = string.Empty;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection = Conexion.GetConexion().crearConexion();
            string queryLogin = "Select nombre from Usuarios where nombre=@nombre and contrasenia=@contrasenia";
            SqlCommand cmd = new SqlCommand(queryLogin, sqlConnection);
            cmd.Parameters.AddWithValue("@nombre",usuario); ;
            cmd.Parameters.AddWithValue("@contrasenia", contrasenia);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            { 
                nombreUsuario = reader["nombre"].ToString();
            }
            reader.Close();
            if(nombreUsuario != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
