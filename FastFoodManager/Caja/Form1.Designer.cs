namespace Caja
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowProductos = new FlowLayoutPanel();
            flowCarrito = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // flowProductos
            // 
            flowProductos.Location = new Point(100, 154);
            flowProductos.Name = "flowProductos";
            flowProductos.Size = new Size(979, 831);
            flowProductos.TabIndex = 0;
            flowProductos.Paint += flowProductos_Paint;
            // 
            // flowCarrito
            // 
            flowCarrito.Location = new Point(1332, 154);
            flowCarrito.Name = "flowCarrito";
            flowCarrito.Size = new Size(1108, 463);
            flowCarrito.TabIndex = 1;
            flowCarrito.Paint += flowCarrito_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 81);
            label1.Name = "label1";
            label1.Size = new Size(251, 32);
            label1.TabIndex = 0;
            label1.Text = "Productos Disponibles";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1332, 81);
            label2.Name = "label2";
            label2.Size = new Size(210, 32);
            label2.TabIndex = 2;
            label2.Text = "Carrito de Compra";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2564, 1399);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowCarrito);
            Controls.Add(flowProductos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowProductos;
        private FlowLayoutPanel flowCarrito;
        private Label label1;
        private Label label2;
    }
}
