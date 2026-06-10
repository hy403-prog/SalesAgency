using System;
using System.Data;
using System.Windows.Forms;

namespace PracticaParcial
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarCategorias();
            ListarProductos();
        }

        private void CargarProveedores()
        {
            Proveedor objProveedor = new Proveedor();
            DataTable dtProveedores = objProveedor.ListarProveedores();

            cmbProveedor.DataSource = dtProveedores;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "IdProveedor";
        }

        private void CargarCategorias()
        {
            Categoria objCategoria = new Categoria();
            DataTable dtCategorias = objCategoria.ListarCategorias();

            cmbCategoria.DataSource = dtCategorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Rellene todos los campos requeridos");
                return;
            }

            try
            {
                Producto producto = new Producto(
                    0,
                    txtNombre.Text,
                    decimal.Parse(txtPrecio.Text),
                    Convert.ToInt32(cmbCategoria.SelectedValue),
                    Convert.ToInt32(cmbProveedor.SelectedValue),
                    int.Parse(txtStock.Text)
                );

                int resultado = producto.GuardarProducto();

                if (resultado > 0)
                {
                    MessageBox.Show("Producto guardado exitosamente");
                    LimpiarCampos();
                    ListarProductos();
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ListarProductos()
        {
            Producto objProducto = new Producto();
            DataTable dtProductos = objProducto.ListarProductos();

            listViewProductos.Items.Clear();

            foreach (DataRow fila in dtProductos.Rows)
            {
                ListViewItem item = new ListViewItem(fila["IdProducto"].ToString());
                item.SubItems.Add(fila["Nombre"].ToString());
                item.SubItems.Add(fila["Precio"].ToString());
                item.SubItems.Add(fila["CantidadStock"].ToString());
                item.SubItems.Add(fila["NombreProveedor"].ToString());
                item.SubItems.Add(fila["NombreCategoria"].ToString());

                listViewProductos.Items.Add(item);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            if (cmbProveedor.Items.Count > 0)
                cmbProveedor.SelectedIndex = 0;

            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;
        }
    }
}