using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial
{
    internal class DetalleVenta
    {
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int CantidadVendida { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }

        public DetalleVenta() { }

        public DetalleVenta(int idVenta, int idProducto, int cantidadVendida, decimal precioUnitario)
        {
            this.IdVenta = idVenta;
            this.IdProducto = idProducto;
            this.CantidadVendida = cantidadVendida;
            this.PrecioUnitario = precioUnitario;
            this.SubTotal = cantidadVendida * precioUnitario;
        }

        // Guardar detalle de venta
        public int GuardarDetalleVenta()
        {
            int resultado = 0;
            SqlConnection conexSQL = Conexion.GetConexion().crearConexion();
            string queryInsert = @"
                INSERT INTO DetalleVentas (IdVenta, IdProducto, CantidadVendida, PrecioUnitario, SubTotal) 
                VALUES(@idventa, @idproducto, @cantidad, @precio, @subtotal)
            ";
            SqlCommand cmd = new SqlCommand(queryInsert, conexSQL);
            cmd.Parameters.AddWithValue("@idventa", this.IdVenta);
            cmd.Parameters.AddWithValue("@idproducto", this.IdProducto);
            cmd.Parameters.AddWithValue("@cantidad", this.CantidadVendida);
            cmd.Parameters.AddWithValue("@precio", this.PrecioUnitario);
            cmd.Parameters.AddWithValue("@subtotal", this.SubTotal);

            conexSQL.Open();
            resultado = cmd.ExecuteNonQuery();
            conexSQL.Close();

            return resultado;
        }

        // Actualizar stock del producto después de venta
        public int ActualizarStockProducto(int idProducto, int cantidadVendida)
        {
            int resultado = 0;
            SqlConnection conexSQL = Conexion.GetConexion().crearConexion();
            string queryUpdate = @"
                UPDATE Productos 
                SET CantidadStock = CantidadStock - @cantidad 
                WHERE IdProducto = @idproducto
            ";
            SqlCommand cmd = new SqlCommand(queryUpdate, conexSQL);
            cmd.Parameters.AddWithValue("@cantidad", cantidadVendida);
            cmd.Parameters.AddWithValue("@idproducto", idProducto);

            conexSQL.Open();
            resultado = cmd.ExecuteNonQuery();
            conexSQL.Close();

            return resultado;
        }

        // Verificar si hay stock disponible
        public bool VerificarStock(int idProducto, int cantidadRequerida)
        {
            SqlConnection conex = Conexion.GetConexion().crearConexion();
            string consulta = "SELECT CantidadStock FROM Productos WHERE IdProducto = @idproducto";
            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@idproducto", idProducto);

            conex.Open();
            object result = cmd.ExecuteScalar();
            conex.Close();

            if (result != null && result != DBNull.Value)
            {
                int stockDisponible = Convert.ToInt32(result);
                return stockDisponible >= cantidadRequerida;
            }
            return false;
        }
    }
}
