using System;
using System.Data;
using System.Data.SqlClient;

namespace PracticaParcial
{
    internal class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CantidadStock { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }

        public Producto() { }

        public Producto(int idProducto, string nombre, decimal precio,
                        int cantidadStock, int idProveedor, int idCategoria)
        {
            this.IdProducto = idProducto;
            this.Nombre = nombre;
            this.Precio = precio;
            this.CantidadStock = cantidadStock;
            this.IdProveedor = idProveedor;
            this.IdCategoria = idCategoria;
        }

        // GUARDAR PRODUCTO
        public int GuardarProducto()
        {
            int resultado = 0;

            SqlConnection conexSQL = Conexion.GetConexion().crearConexion();

            string queryInsert = @"
                INSERT INTO Productos 
                (Nombre, Precio, CantidadStock, IdProveedor, IdCategoria) 
                VALUES
                (@nombre, @precio, @stock, @idproveedor, @idcategoria)
            ";

            SqlCommand cmd = new SqlCommand(queryInsert, conexSQL);

            cmd.Parameters.AddWithValue("@nombre", this.Nombre);
            cmd.Parameters.AddWithValue("@precio", this.Precio);
            cmd.Parameters.AddWithValue("@stock", this.CantidadStock);
            cmd.Parameters.AddWithValue("@idproveedor", this.IdProveedor);
            cmd.Parameters.AddWithValue("@idcategoria", this.IdCategoria);

            conexSQL.Open();
            resultado = cmd.ExecuteNonQuery();
            conexSQL.Close();

            return resultado;
        }

        // LISTAR PRODUCTOS
        public DataTable ListarProductos()
        {
            SqlConnection conex = Conexion.GetConexion().crearConexion();

            DataTable dtProductos = new DataTable();

            string consulta = @"
                SELECT 
                    p.IdProducto,
                    p.Nombre,
                    p.Precio,
                    p.CantidadStock,
                    pr.Nombre AS NombreProveedor,
                    c.Nombre AS NombreCategoria
                FROM Productos p
                INNER JOIN Proveedores pr
                    ON p.IdProveedor = pr.IdProveedor
                INNER JOIN Categoria c
                    ON p.IdCategoria = c.IdCategoria
            ";

            SqlDataAdapter daProducto = new SqlDataAdapter(consulta, conex);

            daProducto.Fill(dtProductos);

            conex.Close();

            return dtProductos;
        }
    }
}