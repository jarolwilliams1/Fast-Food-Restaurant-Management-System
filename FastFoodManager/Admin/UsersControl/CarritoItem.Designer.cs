namespace Admin.UsersControl
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
            lblNombre.Location = new Point(580, 105);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(78, 32);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "label1";
            // 
            // lblPrecioUnit
            // 
            lblPrecioUnit.AutoSize = true;
            lblPrecioUnit.Location = new Point(648, 215);
            lblPrecioUnit.Name = "lblPrecioUnit";
            lblPrecioUnit.Size = new Size(78, 32);
            lblPrecioUnit.TabIndex = 1;
            lblPrecioUnit.Text = "label2";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(770, 81);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(78, 32);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "label3";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(790, 186);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(78, 32);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "label4";
            // 
            // btnMas
            // 
            btnMas.Location = new Point(581, 309);
            btnMas.Name = "btnMas";
            btnMas.Size = new Size(150, 46);
            btnMas.TabIndex = 4;
            btnMas.Text = "button1";
            btnMas.UseVisualStyleBackColor = true;
            // 
            // btnMenos
            // 
            btnMenos.Location = new Point(555, 38);
            btnMenos.Name = "btnMenos";
            btnMenos.Size = new Size(150, 46);
            btnMenos.TabIndex = 5;
            btnMenos.Text = "button2";
            btnMenos.UseVisualStyleBackColor = true;
            btnMenos.Click += button2_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(70, 38);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 46);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "button3";
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
            Size = new Size(876, 394);
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
