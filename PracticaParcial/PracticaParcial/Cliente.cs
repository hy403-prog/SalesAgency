using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial
{
    internal class Cliente
    {
        public int ID { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set;}

        public Cliente()
        {
            
        }

        public Cliente(string nit, string nombre, string apellidos)
        {
            this.Nit = nit;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
        }
        public Cliente(int id, string nit, string nombre, string apellidos)
        {
            this.ID = id;
            this.Nit = nit;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
        }

        //metodo para guardar clientes en la BD
        public int GuardarCliente()
        {
            int resultado = 0;
            SqlConnection conexSQL = new SqlConnection();
            conexSQL = Conexion.GetConexion().crearConexion();
            string queryInsert = "INSERT INTO Cliente (Nit, Nombre, Apellidos) VALUES(@nit, @nombre, @apellidos)";
            SqlCommand cmd = new SqlCommand(queryInsert, conexSQL);
            cmd.Parameters.AddWithValue("@nit", this.Nit);
            cmd.Parameters.AddWithValue("@nombre", this.Nombre);
            cmd.Parameters.AddWithValue("@apellidos", this.Apellidos);
            conexSQL.Open();
            resultado= cmd.ExecuteNonQuery();
            conexSQL.Close();

            return resultado;
        }

        public DataTable ListarClientes()
        {
            SqlConnection conex = null;
            DataTable dtClientes = new DataTable();
            string consulta = "select IdCliente, Nit, Nombre, Apellidos from Cliente";
            conex = Conexion.GetConexion().crearConexion();
            SqlDataAdapter daCliente = new SqlDataAdapter(consulta, conex);
            daCliente.Fill(dtClientes);
            conex.Close();
            return dtClientes;
        }

        public int ActualizarCliente()
        {
            int resultado = 0;
            SqlConnection conexSQL = new SqlConnection();
            conexSQL = Conexion.GetConexion().crearConexion();
            string queryUpdate = "UPDATE Cliente SET Nit=@nit, Nombre=@nombre, Apellidos=@apellidos WHERE IdCliente=@ID";
            SqlCommand cmd = new SqlCommand(queryUpdate, conexSQL);
            cmd.Parameters.AddWithValue("@ID", this.ID);
            cmd.Parameters.AddWithValue("@nit", this.Nit);
            cmd.Parameters.AddWithValue("@nombre", this.Nombre);
            cmd.Parameters.AddWithValue("@apellidos", this.Apellidos);
            conexSQL.Open();
            resultado = cmd.ExecuteNonQuery();
            conexSQL.Close();
            return resultado;
        }

        public int EliminarCliente(int IdCliente)
        {

            int resultado = 0;
            SqlConnection conexSQL = new SqlConnection();
            conexSQL = Conexion.GetConexion().crearConexion();
            string queryDelete = "DELETE FROM Cliente WHERE IdCliente=@ID";
            SqlCommand cmd = new SqlCommand(queryDelete, conexSQL);
            cmd.Parameters.AddWithValue("@ID", IdCliente);
            conexSQL.Open();
            resultado = cmd.ExecuteNonQuery();
            conexSQL.Close();
            return resultado;
        }
    }
}
