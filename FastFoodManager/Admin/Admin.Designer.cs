namespace Admin
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
            groupBox1 = new GroupBox();
            button5 = new Button();
            label2 = new Label();
            button4 = new Button();
            label3 = new Label();
            button3 = new Button();
            label1 = new Label();
            bMenu = new Button();
            Bcaja = new Button();
            groupBoxCaja = new GroupBox();
            groupBoxMenu = new GroupBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            groupBox1.SuspendLayout();
            groupBoxCaja.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(3, 2, 19);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(bMenu);
            groupBox1.Controls.Add(Bcaja);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(440, 1399);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(3, 2, 19);
            button5.ForeColor = Color.White;
            button5.Location = new Point(33, 689);
            button5.Name = "button5";
            button5.Size = new Size(366, 81);
            button5.TabIndex = 7;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(33, 87);
            label2.Name = "label2";
            label2.Size = new Size(216, 32);
            label2.TabIndex = 2;
            label2.Text = "Panel de Control";
            // 
            // button4
            // 
            button4.Location = new Point(33, 561);
            button4.Name = "button4";
            button4.Size = new Size(366, 81);
            button4.TabIndex = 6;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(-4, 136);
            label3.Name = "label3";
            label3.Size = new Size(454, 32);
            label3.TabIndex = 8;
            label3.Text = "____________________________________________";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(3, 2, 19);
            button3.Font = new Font("Arial", 12F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(33, 433);
            button3.Name = "button3";
            button3.Size = new Size(366, 81);
            button3.TabIndex = 5;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(245, 74, 0);
            label1.Location = new Point(33, 35);
            label1.Name = "label1";
            label1.Size = new Size(288, 42);
            label1.TabIndex = 1;
            label1.Text = "FastFood Admin";
            label1.Click += label1_Click;
            // 
            // bMenu
            // 
            bMenu.BackColor = Color.FromArgb(3, 2, 19);
            bMenu.Font = new Font("Arial", 12F);
            bMenu.ForeColor = Color.White;
            bMenu.Location = new Point(33, 321);
            bMenu.Name = "bMenu";
            bMenu.Size = new Size(366, 81);
            bMenu.TabIndex = 4;
            bMenu.Text = "Gestion Menu";
            bMenu.UseVisualStyleBackColor = false;
            bMenu.Click += bMenu_Click;
            // 
            // Bcaja
            // 
            Bcaja.BackColor = Color.FromArgb(3, 2, 19);
            Bcaja.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Bcaja.ForeColor = Color.White;
            Bcaja.Location = new Point(33, 203);
            Bcaja.Name = "Bcaja";
            Bcaja.Size = new Size(366, 81);
            Bcaja.TabIndex = 3;
            Bcaja.Text = "Caja";
            Bcaja.UseVisualStyleBackColor = false;
            Bcaja.Click += Bcaja_Click;
            // 
            // groupBoxCaja
            // 
            groupBoxCaja.Controls.Add(groupBoxMenu);
            groupBoxCaja.Dock = DockStyle.Fill;
            groupBoxCaja.Location = new Point(440, 0);
            groupBoxCaja.Name = "groupBoxCaja";
            groupBoxCaja.Size = new Size(2124, 1399);
            groupBoxCaja.TabIndex = 9;
            groupBoxCaja.TabStop = false;
            groupBoxCaja.Text = "groupBoxCaja";
            groupBoxCaja.Visible = false;
            groupBoxCaja.Enter += groupBoxCaja_Enter;
            // 
            // groupBoxMenu
            // 
            groupBoxMenu.Dock = DockStyle.Fill;
            groupBoxMenu.Location = new Point(3, 35);
            groupBoxMenu.Name = "groupBoxMenu";
            groupBoxMenu.Size = new Size(2118, 1361);
            groupBoxMenu.TabIndex = 0;
            groupBoxMenu.TabStop = false;
            groupBoxMenu.Text = "groupBoxMenu";
            groupBoxMenu.Visible = false;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2564, 1399);
            Controls.Add(groupBoxCaja);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxCaja.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Button Bcaja;
        private Button bMenu;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label3;
        private GroupBox groupBoxCaja;
        private GroupBox groupBoxMenu;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}
