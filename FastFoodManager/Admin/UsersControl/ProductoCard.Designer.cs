namespace Admin.UsersControl
{
    partial class ProductoCard
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
            lblPrecio = new Label();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(45, 28);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(86, 37);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "label1";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.ForeColor = Color.LimeGreen;
            lblPrecio.Location = new Point(45, 84);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(78, 32);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "label1";
            // 
            // ProductoCard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Name = "ProductoCard";
            Size = new Size(436, 159);
            Load += ProductoCard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblPrecio;
    }
}
