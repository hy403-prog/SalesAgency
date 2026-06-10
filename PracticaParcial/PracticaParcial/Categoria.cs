using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial
{
    internal class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria(){}
        public Categoria (string nombre,  string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }
        public int GuardarCategoria()
        {
            int resultado = 0;
            SqlConnection conexSQL = Conexion.GetConexion().crearConexion();
            string queryInsert = "INSERT INTO Categorias (Nombre, Descripcion) VALUES(@nombre, @descripcion)";
            SqlCommand cmd = new SqlCommand(queryInsert, conexSQL);
            cmd.Parameters.AddWithValue("@nombre", this.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", this.Descripcion ?? "");
            conexSQL.Open();
            resultado = cmd.ExecuteNonQuery();
            conexSQL.Close();
            return resultado;
        }
        public DataTable ListarCategorias()
        {
            SqlConnection conex = Conexion.GetConexion().crearConexion();
            DataTable dtCategorias = new DataTable();
            string consulta = "SELECT IdCategoria, Nombre, Descripcion FROM Categorias";
            SqlDataAdapter daCategoria = new SqlDataAdapter(consulta, conex);
            daCategoria.Fill(dtCategorias);
            conex.Close();
            return dtCategorias;
        }

    }
}
