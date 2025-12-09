
namespace LoginEmpleado
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
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(245, 74, 0);
            button1.Font = new Font("Arial Narrow", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(177, 388);
            button1.Name = "button1";
            button1.Size = new Size(344, 78);
            button1.TabIndex = 0;
            button1.Text = "Inicar seción";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(110, 106);
            label2.Name = "label2";
            label2.Size = new Size(92, 32);
            label2.TabIndex = 2;
            label2.Text = "usuario";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 237);
            label3.Name = "label3";
            label3.Size = new Size(130, 32);
            label3.TabIndex = 3;
            label3.Text = "contraseña";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.Location = new Point(110, 161);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "User";
            textBox1.Size = new Size(510, 39);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.AccessibleName = "";
            textBox2.Location = new Point(110, 292);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.PlaceholderText = "Password";
            textBox2.Size = new Size(510, 39);
            textBox2.TabIndex = 5;
            textBox2.Tag = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(497, 623);
            label4.Name = "label4";
            label4.Size = new Size(346, 64);
            label4.TabIndex = 7;
            label4.Text = "Eres nuevo y no tienes cuenta?\r\n\r\n";
            label4.Click += label4_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(849, 623);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(252, 32);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "INICIA SECCION AQUI ";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Location = new Point(481, 115);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(665, 695);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1784, 972);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

       

        #endregion

        private Button button1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private LinkLabel linkLabel1;
        private GroupBox groupBox1;
    }
}
