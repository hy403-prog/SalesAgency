using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaParcial
{
    public partial class FrmVenta : Form
    {
        private List<DetalleVenta> detallesVenta = new List<DetalleVenta>();

        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
        }

        private void CargarClientes()
        {
            DataTable dtClientes = new DataTable();
            Cliente objCliente = new Cliente();
            dtClientes = objCliente.ListarClientes();

            cmbCliente.DataSource = dtClientes;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "IdCliente";
        }

        private void CargarProductos()
        {
            DataTable dtProductos = new DataTable();
            Producto objProducto = new Producto();
            dtProductos = objProducto.ListarProductos();

            cmbProducto.DataSource = dtProductos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IdProducto";
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show("Ingrese la cantidad");
                    return;
                }

                int cantidad = int.Parse(txtCantidad.Text);
                int idProducto = Convert.ToInt32(cmbProducto.SelectedValue);

                // Verificar stock
                DetalleVenta objDetalle = new DetalleVenta();
                if (!objDetalle.VerificarStock(idProducto, cantidad))
                {
                    MessageBox.Show("Stock insuficiente para este producto");
                    return;
                }

                // Obtener precio del producto
                DataTable dtProducto = new DataTable();
                Producto objProducto = new Producto();
                dtProducto = objProducto.ListarProductos();

                decimal precioUnitario = 0;
                foreach (DataRow fila in dtProducto.Rows)
                {
                    if (Convert.ToInt32(fila["IdProducto"]) == idProducto)
                    {
                        precioUnitario = Convert.ToDecimal(fila["Precio"]);
                        break;
                    }
                }

                // Crear detalle de venta
                DetalleVenta detalle = new DetalleVenta(0, idProducto, cantidad, precioUnitario);
                detallesVenta.Add(detalle);

                // Agregar a ListView
                ListViewItem listItem = new ListViewItem(cmbProducto.Text);
                listItem.SubItems.Add(cantidad.ToString());
                listItem.SubItems.Add(precioUnitario.ToString("C"));
                listItem.SubItems.Add(detalle.SubTotal.ToString("C"));
                listViewDetalles.Items.Add(listItem);

                // Actualizar total
                ActualizarTotal();

                // Limpiar campos
                txtCantidad.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (var detalle in detallesVenta)
            {
                total += detalle.SubTotal;
            }

            // Aplicar descuento
            if (!string.IsNullOrWhiteSpace(txtDescuento.Text))
            {
                decimal descuento = decimal.Parse(txtDescuento.Text);
                total -= descuento;
            }

            txtTotal.Text = total.ToString("C");
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (detallesVenta.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un producto a la venta");
                    return;
                }

                int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
                decimal descuento = string.IsNullOrWhiteSpace(txtDescuento.Text) ? 0 : decimal.Parse(txtDescuento.Text);
                decimal total = decimal.Parse(txtTotal.Text.Replace("$", "").Replace(",", "."));

                // Crear y guardar venta
                Venta objVenta = new Venta(idCliente, descuento, total);
                int resultado = objVenta.GuardarVenta();

                if (resultado > 0)
                {
                    // Obtener ID de la venta recién creada
                    int idVenta = objVenta.ObtenerUltimaVenta();

                    // Guardar detalles de venta y actualizar stock
                    foreach (var detalle in detallesVenta)
                    {
                        detalle.IdVenta = idVenta;
                        detalle.GuardarDetalleVenta();
                        detalle.ActualizarStockProducto(detalle.IdProducto, detalle.CantidadVendida);
                    }

                    MessageBox.Show("Venta registrada exitosamente");
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Error al registrar la venta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarFormulario()
        {
            detallesVenta.Clear();
            listViewDetalles.Items.Clear();
            txtCantidad.Text = "";
            txtDescuento.Text = "0";
            txtTotal.Text = "0.00";
        }
    }
}