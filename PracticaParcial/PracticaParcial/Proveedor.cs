using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial
{
    internal class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string PaginaWeb { get; set; }
        public Proveedor() { }

        public Proveedor(string nit, String nombre, string direccion, string telefono, string paginaweb)
        {
           this.Nit = nit;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.PaginaWeb = paginaweb;
        }

        //guardar proveedor
        public int GuardarProveedor()
        {
            int resultado = 0;
            SqlConnection conexSQL = Conexion.GetConexion().crearConexion();
            string queryInsert = "INSERT INTO Proveedores (Nit, Nombre, Direccion, Telefono, PaginaWeb) VALUES(@nit, @nombre, @direccion, @telefono, @paginaweb)";
            SqlCommand cmd = new SqlCommand(queryInsert, conexSQL);
            cmd.Parameters.AddWithValue("@nit", this.Nit);
            cmd.Parameters.AddWithValue("@nombre", this.Nombre);
            cmd.Parameters.AddWithValue("@direccion", this.Direccion ?? "");
            cmd.Parameters.AddWithValue("@telefono", this.Telefono ?? "");
            cmd.Parameters.AddWithValue("@paginaweb", this.PaginaWeb ?? "");
            conexSQL.Open();
            resultado = cmd.ExecuteNonQuery();
            conexSQL.Close();
            return resultado;
        }
        public DataTable ListarProveedores()
        {
            SqlConnection conex = Conexion.GetConexion().crearConexion();
            DataTable dtProveedores = new DataTable();
            string consulta = "SELECT IdProveedor, Nit, Nombre, Direccion, Telefono, PaginaWeb FROM Proveedores";
            SqlDataAdapter daProveedor = new SqlDataAdapter(consulta, conex);
            daProveedor.Fill(dtProveedores);
            conex.Close();
            return dtProveedores;
        }
    }
}
