using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial
{
    public class Conexion
    {
        private string BaseDeDatos;
        private string Servidor;

        private static Conexion con = null;

        private Conexion()
        {
            this.BaseDeDatos = "PracticaParcial";
            this.Servidor = "DESKTOP-H28QSF6";
        }

        //metodo para generar la cadena de conexion
        public SqlConnection crearConexion()
        {
            SqlConnection cadConex = new SqlConnection();
            cadConex.ConnectionString = "Server=" + this.Servidor +
                "; Database=" + this.BaseDeDatos +
                "; integrated security=SSPI";

            return cadConex;
        }

        public static Conexion GetConexion()
        {
            if (con == null)
            {
                con = new Conexion();
            }

            return con;
        }
    }
}
