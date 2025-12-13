namespace Menu
{
    partial class Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            DescripcionProducto = new TextBox();
            EstadoProducto = new ComboBox();
            categoriaProducto = new ComboBox();
            bCancelar = new Button();
            bAgregarProducto = new Button();
            NombreProducto = new TextBox();
            PrecioProducto = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DescripcionProducto);
            groupBox1.Controls.Add(EstadoProducto);
            groupBox1.Controls.Add(categoriaProducto);
            groupBox1.Controls.Add(bCancelar);
            groupBox1.Controls.Add(bAgregarProducto);
            groupBox1.Controls.Add(NombreProducto);
            groupBox1.Controls.Add(PrecioProducto);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(121, 366);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(2319, 667);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Visible = false;
            groupBox1.Enter += groupBox1_Enter_1;
            // 
            // DescripcionProducto
            // 
            DescripcionProducto.Location = new Point(70, 381);
            DescripcionProducto.Multiline = true;
            DescripcionProducto.Name = "DescripcionProducto";
            DescripcionProducto.PlaceholderText = "Descripción del producto";
            DescripcionProducto.Size = new Size(791, 195);
            DescripcionProducto.TabIndex = 16;
            // 
            // EstadoProducto
            // 
            EstadoProducto.AccessibleName = "";
            EstadoProducto.FormattingEnabled = true;
            EstadoProducto.Items.AddRange(new object[] { "Disponible", "No Disponible" });
            EstadoProducto.Location = new Point(772, 256);
            EstadoProducto.Name = "EstadoProducto";
            EstadoProducto.Size = new Size(684, 40);
            EstadoProducto.TabIndex = 15;
            EstadoProducto.Tag = "";
            // 
            // categoriaProducto
            // 
            categoriaProducto.DisplayMember = "Seleccion";
            categoriaProducto.FormattingEnabled = true;
            categoriaProducto.Items.AddRange(new object[] { "Hamburguesas", "Pizzas", "Hot Dogs", "Acompañamientos", "Bebidas" });
            categoriaProducto.Location = new Point(772, 125);
            categoriaProducto.Name = "categoriaProducto";
            categoriaProducto.Size = new Size(684, 40);
            categoriaProducto.TabIndex = 13;
            // 
            // bCancelar
            // 
            bCancelar.BackColor = Color.Gray;
            bCancelar.ForeColor = Color.White;
            bCancelar.Location = new Point(248, 601);
            bCancelar.Name = "bCancelar";
            bCancelar.Size = new Size(150, 46);
            bCancelar.TabIndex = 12;
            bCancelar.Text = "Cancelar";
            bCancelar.UseVisualStyleBackColor = false;
            bCancelar.Click += bCancelar_Click;
            // 
            // bAgregarProducto
            // 
            bAgregarProducto.BackColor = Color.Coral;
            bAgregarProducto.ForeColor = Color.White;
            bAgregarProducto.Location = new Point(61, 601);
            bAgregarProducto.Name = "bAgregarProducto";
            bAgregarProducto.Size = new Size(150, 46);
            bAgregarProducto.TabIndex = 11;
            bAgregarProducto.Text = "Agregar";
            bAgregarProducto.UseVisualStyleBackColor = false;
            bAgregarProducto.Click += button2_Click;
            // 
            // NombreProducto
            // 
            NombreProducto.Location = new Point(70, 126);
            NombreProducto.Name = "NombreProducto";
            NombreProducto.Size = new Size(560, 39);
            NombreProducto.TabIndex = 5;
            // 
            // PrecioProducto
            // 
            PrecioProducto.Location = new Point(70, 256);
            PrecioProducto.Name = "PrecioProducto";
            PrecioProducto.Size = new Size(560, 39);
            PrecioProducto.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(70, 208);
            label8.Name = "label8";
            label8.Size = new Size(84, 32);
            label8.TabIndex = 5;
            label8.Text = "Precio:";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(70, 332);
            label7.Name = "label7";
            label7.Size = new Size(143, 32);
            label7.TabIndex = 4;
            label7.Text = "Descripcion:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(772, 208);
            label5.Name = "label5";
            label5.Size = new Size(89, 32);
            label5.TabIndex = 2;
            label5.Text = "Estado:";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(772, 69);
            label4.Name = "label4";
            label4.Size = new Size(121, 32);
            label4.TabIndex = 1;
            label4.Text = "Categoria:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 78);
            label2.Name = "label2";
            label2.Size = new Size(236, 32);
            label2.TabIndex = 0;
            label2.Text = "Nombre del Poducto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(114, 61);
            label1.Name = "label1";
            label1.Size = new Size(405, 43);
            label1.TabIndex = 6;
            label1.Text = "Gestión de Productos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(121, 113);
            label3.Name = "label3";
            label3.Size = new Size(463, 40);
            label3.TabIndex = 7;
            label3.Text = "Administra los productos del menú";
            // 
            // button1
            // 
            button1.BackColor = Color.Coral;
            button1.Font = new Font("Lucida Sans Unicode", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(2145, 113);
            button1.Name = "button1";
            button1.Size = new Size(295, 60);
            button1.TabIndex = 8;
            button1.Text = "+ Nuevo Producto";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Productos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2564, 1399);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Name = "Productos";
            Text = "Productos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox NombreProducto;
        private TextBox PrecioProducto;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button button1;
        private Button bCancelar;
        private Button bAgregarProducto;
        private ComboBox categoriaProducto;
        private ComboBox EstadoProducto;
        private TextBox DescripcionProducto;
    }
}