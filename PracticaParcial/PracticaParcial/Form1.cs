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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            if (user.login(txtUsuarios.Text, txtContrasenia.Text))
            {
                MessageBox.Show("Login Exitoso");
                FrmMenuPrincipal menu = new FrmMenuPrincipal();
                menu.ShowDialog(this);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error, nombre de usuario o contrasenia incorrectos");
            }

        }
    }
}
