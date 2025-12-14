using System.Windows.Forms;

namespace Menu
{
    partial class Pedidos
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
            label3 = new Label();
            button1 = new Button();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(100, 52);
            label1.Name = "label1";
            label1.Size = new Size(365, 43);
            label1.TabIndex = 0;
            label1.Text = "Gestión de Pedidos";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(107, 104);
            label3.Name = "label3";
            label3.Size = new Size(486, 40);
            label3.TabIndex = 2;
            label3.Text = "Administra todos los pedidos activos";
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Lucida Sans Unicode", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(2124, 45);
            button1.Name = "button1";
            button1.Size = new Size(295, 60);
            button1.TabIndex = 3;
            button1.Text = "+ Nuevo Pedido";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(100, 237);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(2319, 667);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Visible = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 126);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(443, 39);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(870, 338);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(200, 39);
            textBox6.TabIndex = 10;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(807, 126);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(353, 39);
            textBox5.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1523, 110);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(200, 39);
            textBox4.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1488, 351);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 39);
            textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(70, 302);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 39);
            textBox2.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(70, 255);
            label8.Name = "label8";
            label8.Size = new Size(78, 32);
            label8.TabIndex = 5;
            label8.Text = "label8";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1488, 302);
            label7.Name = "label7";
            label7.Size = new Size(78, 32);
            label7.TabIndex = 4;
            label7.Text = "label7";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1536, 75);
            label6.Name = "label6";
            label6.Size = new Size(78, 32);
            label6.TabIndex = 3;
            label6.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(911, 272);
            label5.Name = "label5";
            label5.Size = new Size(78, 32);
            label5.TabIndex = 2;
            label5.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(807, 78);
            label4.Name = "label4";
            label4.Size = new Size(114, 32);
            label4.TabIndex = 1;
            label4.Text = "Direccion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 78);
            label2.Name = "label2";
            label2.Size = new Size(102, 32);
            label2.TabIndex = 0;
            label2.Text = "Nombre";
            // 
            // Pedidos
            // 
            AutoScroll = true;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2564, 1399);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label3);
            Name = "Pedidos";
            Text = "Pedidos";
            Load += Pedidos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Button button1;
        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label8;
        private Label label7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}