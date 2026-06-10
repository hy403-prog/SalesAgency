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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            Cliente cliente = new Cliente(txtNit.Text, txtNombre.Text, txtApellidos.Text);
            resultado = cliente.GuardarCliente();
            if (resultado > 0)
            {
                MessageBox.Show("Datos almacenados exitosamente");
                listarDatos();
            }
            else
            {
                MessageBox.Show("Ocurrio un erro");
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            listarDatos();
        }

        private void listarDatos()
        {
            DataTable dtclient = new DataTable();
            Cliente objCliente = new Cliente();
            dtclient = objCliente.ListarClientes();
            //limpiar listview
            listViewClientes.Items.Clear();

            foreach (DataRow fila in dtclient.Rows)
            {
                ListViewItem listItem = new ListViewItem(fila["IdCliente"].ToString());
                listItem.SubItems.Add(fila["Nit"].ToString());
                listItem.SubItems.Add(fila["Nombre"].ToString());
                listItem.SubItems.Add(fila["Apellidos"].ToString());
                listViewClientes.Items.Add(listItem);

            }
        }

        private void listViewClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //verificar que el litview tenga datos
            if (listViewClientes.SelectedItems.Count > 0)
            {
                //obtener la fila seleccionada del listview
                ListViewItem filaSeleccionada = listViewClientes.SelectedItems[0];
                //obtner el valor de IdCliente y se obtiene por el indice, en este caso 0
                string IdCliente = filaSeleccionada.SubItems[0].Text;
                //obtner el valor de nit y se obtiene por el indice, en este caso 1
                string nit = filaSeleccionada.SubItems[1].Text;
                //obtner el valor del Nombre del cliente y se obtiene por el indice, en este caso 2
                string nombre = filaSeleccionada.SubItems[2].Text;
                //obtner el valor del Apellidos del cliente y se obtiene por el indice, en este caso 3
                string apellidos = filaSeleccionada.SubItems[3].Text;
                //asignamos a las cajas de texto correspondientes los datos seleccionados
                txtNit.Text = nit;
                txtNombre.Text = nombre;
                txtApellidos.Text = apellidos;
                //para el caso del nidcliente se crea un label con name lblId y le asignamos el valor
                lblId.Text = IdCliente;
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            Cliente objCliente = new Cliente(int.Parse(lblId.Text), txtNit.Text, txtNombre.Text, txtApellidos.Text);
            resultado = objCliente.ActualizarCliente();
            if (resultado > 0)
            {
                listarDatos();
                MessageBox.Show("Cliente acutalizado exitosamente");
            }
            else
            {
                MessageBox.Show("El Registro no se actualizó");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int result = 0;
            Cliente objCategoria = new Cliente();
            result = objCategoria.EliminarCliente(int.Parse(lblId.Text));
            if (result > 0)
            {
                listarDatos();
                MessageBox.Show("Registro eliminado");

            }
            else
            {
                MessageBox.Show("No se elimino ningún registro");
            }
        }
    }
}
