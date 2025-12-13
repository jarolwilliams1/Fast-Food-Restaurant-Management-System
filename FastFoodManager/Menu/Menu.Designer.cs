namespace Menu
{
    partial class Menus
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
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            Gpedidos = new GroupBox();
            label3 = new Label();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            label4 = new Label();
            groupBox1.SuspendLayout();
            Gpedidos.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(188, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(2172, 231);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(929, 95);
            label2.Name = "label2";
            label2.Size = new Size(442, 40);
            label2.TabIndex = 1;
            label2.Text = "Seleccione una opción del menú";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(245, 74, 0);
            label1.Location = new Point(958, 55);
            label1.Name = "label1";
            label1.Size = new Size(394, 40);
            label1.TabIndex = 0;
            label1.Text = "Sistema de Gestión FastFood";
            label1.Click += label1_Click;
            // 
            // Gpedidos
            // 
            Gpedidos.BackColor = Color.RoyalBlue;
            Gpedidos.Controls.Add(label3);
            Gpedidos.Location = new Point(188, 330);
            Gpedidos.Name = "Gpedidos";
            Gpedidos.Size = new Size(942, 446);
            Gpedidos.TabIndex = 1;
            Gpedidos.TabStop = false;
            Gpedidos.Enter += Gpedidos_Enter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(267, 284);
            label3.Name = "label3";
            label3.Size = new Size(403, 118);
            label3.TabIndex = 0;
            label3.Text = "Gestión de Pedidos\r\n\r\n";
            label3.Click += label3_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(0, 192, 0);
            groupBox3.Location = new Point(1418, 330);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(942, 446);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(255, 128, 0);
            groupBox4.Controls.Add(label4);
            groupBox4.Location = new Point(188, 842);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(942, 446);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.DarkOrchid;
            groupBox5.Location = new Point(1418, 842);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(942, 446);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(452, 384);
            label4.Name = "label4";
            label4.Size = new Size(165, 32);
            label4.TabIndex = 4;
            label4.Text = "Gestión Menu";
            label4.Click += label4_Click;
            // 
            // Menus
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2564, 1399);
            Controls.Add(groupBox4);
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            Controls.Add(Gpedidos);
            Controls.Add(groupBox1);
            Name = "Menus";
            Text = "Form1";
            Load += Menus_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            Gpedidos.ResumeLayout(false);
            Gpedidos.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox Gpedidos;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
    }
}
