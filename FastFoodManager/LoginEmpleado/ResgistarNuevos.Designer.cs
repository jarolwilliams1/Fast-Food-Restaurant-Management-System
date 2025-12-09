namespace LoginEmpleado
{
    partial class ResgistarNuevos
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            button1 = new Button();
            RolNuevoUusuario = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            ContraseñaNuevoUusuario = new TextBox();
            UsuarioNuevoUusuario = new TextBox();
            label5 = new Label();
            label6 = new Label();
            ApellidoNuevoUusuario = new TextBox();
            label4 = new Label();
            label3 = new Label();
            NombreNuevoUusuario = new TextBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 147);
            label1.Name = "label1";
            label1.Size = new Size(329, 45);
            label1.TabIndex = 2;
            label1.Text = "Informacion Personal";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(RolNuevoUusuario);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(ContraseñaNuevoUusuario);
            groupBox1.Controls.Add(UsuarioNuevoUusuario);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(ApellidoNuevoUusuario);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(NombreNuevoUusuario);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(575, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(748, 1201);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.Location = new Point(156, 1044);
            button1.Name = "button1";
            button1.Size = new Size(418, 76);
            button1.TabIndex = 16;
            button1.Text = "Registrar Empleado";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // RolNuevoUusuario
            // 
            RolNuevoUusuario.FormattingEnabled = true;
            RolNuevoUusuario.Items.AddRange(new object[] { "Cajero", "Repartidor", "Cocinero", "Gerente" });
            RolNuevoUusuario.Location = new Point(61, 958);
            RolNuevoUusuario.Name = "RolNuevoUusuario";
            RolNuevoUusuario.Size = new Size(614, 40);
            RolNuevoUusuario.TabIndex = 15;
            RolNuevoUusuario.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(61, 923);
            label9.Name = "label9";
            label9.Size = new Size(86, 32);
            label9.TabIndex = 14;
            label9.Text = "Puesto";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(61, 798);
            label8.Name = "label8";
            label8.Size = new Size(134, 32);
            label8.TabIndex = 13;
            label8.Text = "Contraseña";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(61, 680);
            label7.Name = "label7";
            label7.Size = new Size(94, 32);
            label7.TabIndex = 12;
            label7.Text = "Usuario";
            label7.Click += label7_Click;
            // 
            // ContraseñaNuevoUusuario
            // 
            ContraseñaNuevoUusuario.Location = new Point(61, 833);
            ContraseñaNuevoUusuario.Name = "ContraseñaNuevoUusuario";
            ContraseñaNuevoUusuario.PasswordChar = '*';
            ContraseñaNuevoUusuario.Size = new Size(601, 39);
            ContraseñaNuevoUusuario.TabIndex = 11;
            // 
            // UsuarioNuevoUusuario
            // 
            UsuarioNuevoUusuario.Location = new Point(61, 715);
            UsuarioNuevoUusuario.Name = "UsuarioNuevoUusuario";
            UsuarioNuevoUusuario.Size = new Size(601, 39);
            UsuarioNuevoUusuario.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(64, 566);
            label5.Name = "label5";
            label5.Size = new Size(317, 40);
            label5.TabIndex = 8;
            label5.Text = "Información de Cuenta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = SystemColors.AppWorkspace;
            label6.Location = new Point(61, 584);
            label6.Name = "label6";
            label6.Size = new Size(614, 32);
            label6.TabIndex = 9;
            label6.Text = "____________________________________________________________";
            // 
            // ApellidoNuevoUusuario
            // 
            ApellidoNuevoUusuario.Location = new Point(61, 430);
            ApellidoNuevoUusuario.Name = "ApellidoNuevoUusuario";
            ApellidoNuevoUusuario.PlaceholderText = "Pérez";
            ApellidoNuevoUusuario.Size = new Size(601, 39);
            ApellidoNuevoUusuario.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 245);
            label4.Name = "label4";
            label4.Size = new Size(102, 32);
            label4.TabIndex = 6;
            label4.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 381);
            label3.Name = "label3";
            label3.Size = new Size(102, 32);
            label3.TabIndex = 5;
            label3.Text = "Apellido";
            // 
            // NombreNuevoUusuario
            // 
            NombreNuevoUusuario.Location = new Point(61, 291);
            NombreNuevoUusuario.Name = "NombreNuevoUusuario";
            NombreNuevoUusuario.PlaceholderText = "Juan";
            NombreNuevoUusuario.Size = new Size(601, 39);
            NombreNuevoUusuario.TabIndex = 4;
            NombreNuevoUusuario.TextChanged += NombreNuevoUusuario_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.AppWorkspace;
            label2.Location = new Point(61, 170);
            label2.Name = "label2";
            label2.Size = new Size(614, 32);
            label2.TabIndex = 3;
            label2.Text = "____________________________________________________________";
            // 
            // ResgistarNuevos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1896, 1399);
            Controls.Add(groupBox1);
            Name = "ResgistarNuevos";
            Text = "ResgistarNuevos";
            Load += ResgistarNuevos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox NombreNuevoUusuario;
        private Label label4;
        private Label label3;
        private Label label5;
        private TextBox ApellidoNuevoUusuario;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox ContraseñaNuevoUusuario;
        private TextBox UsuarioNuevoUusuario;
        private Label label6;
        private ComboBox RolNuevoUusuario;
        private Button button1;
    }
}