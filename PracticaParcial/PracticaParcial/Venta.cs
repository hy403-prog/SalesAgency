using System;
using System.Data;
using System.Data.SqlClient;

namespace PracticaParcial
{
    internal class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public decimal MontoTotal { get; set; }

        public Venta() { }

        public Venta(int idCliente, decimal descuentoAplicado, decimal montoTotal)
        {
            this.IdCliente = idCliente;
            this.FechaVenta = DateTime.Now;
            this.DescuentoAplicado = descuentoAplicado;
            this.MontoTotal = montoTotal;
        }

        // GUARDAR VENTA
        public int GuardarVenta()
        {
            int resultado = 0;

            SqlConnection conexSQL = Conexion.GetConexion().crearConexion();

            string queryInsert = @"
                INSERT INTO Ventas
                (IdCliente, FechaVenta, DescuentoAplicado, MontoTotal)
                VALUES
                (@idcliente, @fechaventa, @descuento, @monto)
            ";

            SqlCommand cmd = new SqlCommand(queryInsert, conexSQL);

            cmd.Parameters.AddWithValue("@idcliente", this.IdCliente);
            cmd.Parameters.AddWithValue("@fechaventa", this.FechaVenta);
            cmd.Parameters.AddWithValue("@descuento", this.DescuentoAplicado);
            cmd.Parameters.AddWithValue("@monto", this.MontoTotal);

            conexSQL.Open();

            resultado = cmd.ExecuteNonQuery();

            conexSQL.Close();

            return resultado;
        }

        // OBTENER ÚLTIMA VENTA
        public int ObtenerUltimaVenta()
        {
            int idVenta = 0;

            SqlConnection conexSQL = Conexion.GetConexion().crearConexion();

            string query = "SELECT MAX(IdVenta) FROM Ventas";

            SqlCommand cmd = new SqlCommand(query, conexSQL);

            conexSQL.Open();

            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                idVenta = Convert.ToInt32(result);
            }

            conexSQL.Close();

            return idVenta;
        }

        // LISTAR VENTAS
        public DataTable ListarVentas()
        {
            SqlConnection conex = Conexion.GetConexion().crearConexion();

            DataTable dtVentas = new DataTable();

            string consulta = @"
                SELECT 
                    v.IdVenta,
                    c.Nombre AS NombreCliente,
                    v.FechaVenta,
                    v.DescuentoAplicado,
                    v.MontoTotal
                FROM Ventas v
                INNER JOIN Cliente c
                    ON v.IdCliente = c.IdCliente
                ORDER BY v.FechaVenta DESC
            ";

            SqlDataAdapter daVenta = new SqlDataAdapter(consulta, conex);

            daVenta.Fill(dtVentas);

            conex.Close();

            return dtVentas;
        }

        // OBTENER DETALLES DE VENTA
        public DataTable ObtenerDetallesVenta(int idVenta)
        {
            SqlConnection conex = Conexion.GetConexion().crearConexion();

            DataTable dtDetalles = new DataTable();

            string consulta = @"
                SELECT 
                    dv.IdDetalle,
                    p.Nombre AS NombreProducto,
                    dv.CantidadVendida,
                    dv.PrecioUnitario,
                    dv.SubTotal
                FROM DetalleVentas dv
                INNER JOIN Productos p
                    ON dv.IdProducto = p.IdProducto
                WHERE dv.IdVenta = @idventa
            ";

            SqlDataAdapter daDetalle = new SqlDataAdapter(consulta, conex);

            daDetalle.SelectCommand.Parameters.AddWithValue("@idventa", idVenta);

            daDetalle.Fill(dtDetalles);

            conex.Close();

            return dtDetalles;
        }
    }
}