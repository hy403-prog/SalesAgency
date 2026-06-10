namespace PracticaParcial
{
    partial class FrmProveedor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNit = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblPaginaWeb = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtPaginaWeb = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.listViewProveedores = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(150, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(118, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Proveedores";

            // lblNit
            this.lblNit.AutoSize = true;
            this.lblNit.Location = new System.Drawing.Point(20, 50);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(28, 13);
            this.lblNit.TabIndex = 1;
            this.lblNit.Text = "NIT:";

            // txtNit
            this.txtNit.Location = new System.Drawing.Point(100, 50);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(150, 20);
            this.txtNit.TabIndex = 2;

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 80);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(100, 80);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.TabIndex = 4;

            // lblDireccion
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(20, 110);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 5;
            this.lblDireccion.Text = "Dirección:";

            // txtDireccion
            this.txtDireccion.Location = new System.Drawing.Point(100, 110);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(150, 20);
            this.txtDireccion.TabIndex = 6;

            // lblTelefono
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(20, 140);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 7;
            this.lblTelefono.Text = "Teléfono:";

            // txtTelefono
            this.txtTelefono.Location = new System.Drawing.Point(100, 140);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(150, 20);
            this.txtTelefono.TabIndex = 8;

            // lblPaginaWeb
            this.lblPaginaWeb.AutoSize = true;
            this.lblPaginaWeb.Location = new System.Drawing.Point(20, 170);
            this.lblPaginaWeb.Name = "lblPaginaWeb";
            this.lblPaginaWeb.Size = new System.Drawing.Size(74, 13);
            this.lblPaginaWeb.TabIndex = 9;
            this.lblPaginaWeb.Text = "Página Web:";

            // txtPaginaWeb
            this.txtPaginaWeb.Location = new System.Drawing.Point(100, 170);
            this.txtPaginaWeb.Name = "txtPaginaWeb";
            this.txtPaginaWeb.Size = new System.Drawing.Size(150, 20);
            this.txtPaginaWeb.TabIndex = 10;

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(100, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // listViewProveedores
            this.listViewProveedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewProveedores.Location = new System.Drawing.Point(20, 240);
            this.listViewProveedores.Name = "listViewProveedores";
            this.listViewProveedores.Size = new System.Drawing.Size(400, 200);
            this.listViewProveedores.TabIndex = 12;
            this.listViewProveedores.UseCompatibleStateImageBehavior = false;
            this.listViewProveedores.View = System.Windows.Forms.View.Details;

            // columnHeader1
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;

            // columnHeader2
            this.columnHeader2.Text = "NIT";
            this.columnHeader2.Width = 80;

            // columnHeader3
            this.columnHeader3.Text = "Nombre";
            this.columnHeader3.Width = 100;

            // columnHeader4
            this.columnHeader4.Text = "Teléfono";
            this.columnHeader4.Width = 80;

            // columnHeader5
            this.columnHeader5.Text = "Página Web";
            this.columnHeader5.Width = 100;

            // FrmProveedor
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.listViewProveedores);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPaginaWeb);
            this.Controls.Add(this.lblPaginaWeb);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNit);
            this.Controls.Add(this.lblNit);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmProveedor";
            this.Text = "Gestión de Proveedores";
            this.Load += new System.EventHandler(this.FrmProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNit;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblPaginaWeb;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtPaginaWeb;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ListView listViewProveedores;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}