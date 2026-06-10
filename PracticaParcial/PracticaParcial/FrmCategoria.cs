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
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            listarCategorias();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría es requerido");
                return;
            }

            int resultado = 0;
            Categoria categoria = new Categoria(txtNombre.Text, txtDescripcion.Text);
            resultado = categoria.GuardarCategoria();

            if (resultado > 0)
            {
                MessageBox.Show("Categoría guardada exitosamente");
                LimpiarCampos();
                listarCategorias();
            }
            else
            {
                MessageBox.Show("Error al guardar la categoría");
            }
        }

        private void listarCategorias()
        {
            DataTable dtCategorias = new DataTable();
            Categoria objCategoria = new Categoria();
            dtCategorias = objCategoria.ListarCategorias();
            listViewCategorias.Items.Clear();

            foreach (DataRow fila in dtCategorias.Rows)
            {
                ListViewItem listItem = new ListViewItem(fila["IdCategoria"].ToString());
                listItem.SubItems.Add(fila["Nombre"].ToString());
                listItem.SubItems.Add(fila["Descripcion"].ToString());
                listViewCategorias.Items.Add(listItem);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }
    }
}