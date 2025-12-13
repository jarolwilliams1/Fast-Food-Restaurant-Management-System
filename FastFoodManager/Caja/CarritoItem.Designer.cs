namespace Caja
{
    partial class CarritoItem
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblNombre = new Label();
            lblPrecioUnit = new Label();
            lblCantidad = new Label();
            lblTotal = new Label();
            btnMas = new Button();
            btnMenos = new Button();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(77, 56);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(78, 32);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "label1";
            // 
            // lblPrecioUnit
            // 
            lblPrecioUnit.AutoSize = true;
            lblPrecioUnit.Location = new Point(77, 131);
            lblPrecioUnit.Name = "lblPrecioUnit";
            lblPrecioUnit.Size = new Size(78, 32);
            lblPrecioUnit.TabIndex = 2;
            lblPrecioUnit.Text = "label1";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(726, 97);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(78, 32);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "label1";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(869, 97);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(78, 32);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "label1";
            // 
            // btnMas
            // 
            btnMas.Location = new Point(810, 97);
            btnMas.Name = "btnMas";
            btnMas.Size = new Size(38, 43);
            btnMas.TabIndex = 5;
            btnMas.Text = "+";
            btnMas.UseVisualStyleBackColor = true;
            // 
            // btnMenos
            // 
            btnMenos.Location = new Point(682, 97);
            btnMenos.Name = "btnMenos";
            btnMenos.Size = new Size(38, 44);
            btnMenos.TabIndex = 6;
            btnMenos.Text = "-";
            btnMenos.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(969, 97);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(50, 47);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "-+";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // CarritoItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnEliminar);
            Controls.Add(btnMenos);
            Controls.Add(btnMas);
            Controls.Add(lblTotal);
            Controls.Add(lblCantidad);
            Controls.Add(lblPrecioUnit);
            Controls.Add(lblNombre);
            Name = "CarritoItem";
            Size = new Size(1066, 397);
            Load += CarritoItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblPrecioUnit;
        private Label lblCantidad;
        private Label lblTotal;
        private Button btnMas;
        private Button btnMenos;
        private Button btnEliminar;
    }
}
