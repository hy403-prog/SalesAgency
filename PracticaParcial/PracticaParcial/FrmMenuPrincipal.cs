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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmCliente cliente = new FrmCliente();
            cliente.ShowDialog(this);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FrmProveedor proveedor = new FrmProveedor();
            proveedor.ShowDialog(this);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategoria categoria = new FrmCategoria();
            categoria.ShowDialog(this);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProducto producto = new FrmProducto();
            producto.ShowDialog(this);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FrmVenta venta = new FrmVenta();
            venta.ShowDialog(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
