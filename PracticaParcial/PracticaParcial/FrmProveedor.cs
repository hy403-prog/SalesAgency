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
    public partial class FrmProveedor : Form
    {
        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            listarProveedores();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNit.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El NIT y Nombre son requeridos");
                return;
            }

            int resultado = 0;
            Proveedor proveedor = new Proveedor(
                txtNit.Text,
                txtNombre.Text,
                txtDireccion.Text,
                txtTelefono.Text,
                txtPaginaWeb.Text
            );

            resultado = proveedor.GuardarProveedor();

            if (resultado > 0)
            {
                MessageBox.Show("Proveedor guardado exitosamente");
                LimpiarCampos();
                listarProveedores();
            }
            else
            {
                MessageBox.Show("Error al guardar el proveedor");
            }
        }

        private void listarProveedores()
        {
            DataTable dtProveedores = new DataTable();
            Proveedor objProveedor = new Proveedor();
            dtProveedores = objProveedor.ListarProveedores();
            listViewProveedores.Items.Clear();

            foreach (DataRow fila in dtProveedores.Rows)
            {
                ListViewItem listItem = new ListViewItem(fila["IdProveedor"].ToString());
                listItem.SubItems.Add(fila["Nit"].ToString());
                listItem.SubItems.Add(fila["Nombre"].ToString());
                listItem.SubItems.Add(fila["Telefono"].ToString());
                listItem.SubItems.Add(fila["PaginaWeb"].ToString());
                listViewProveedores.Items.Add(listItem);
            }
        }

        private void LimpiarCampos()
        {
            txtNit.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtPaginaWeb.Text = "";
        }
    }
}