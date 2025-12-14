namespace Caja
{
    partial class Flowproductocard
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
            flproduct = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(75, 36);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(78, 32);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "label1";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(75, 113);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(78, 32);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "label1";
            lblPrecio.Click += label1_Click;
            // 
            // flproduct
            // 
            flproduct.Location = new Point(38, 12);
            flproduct.Name = "flproduct";
            flproduct.Size = new Size(346, 181);
            flproduct.TabIndex = 2;
            // 
            // Flowproductocard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Coral;
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Controls.Add(flproduct);
            Name = "Flowproductocard";
            Size = new Size(441, 205);
            Load += ProductoCard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblPrecio;
        private FlowLayoutPanel flproduct;
    }
}
