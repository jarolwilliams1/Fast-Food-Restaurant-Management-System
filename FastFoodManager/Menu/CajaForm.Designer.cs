namespace Menu
{
    partial class CajaForm
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
        /// 

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CajaForm
            // 
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(2590, 1470);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CajaForm";
            Text = "Caja";
            WindowState = FormWindowState.Maximized;
            Load += CajaForm_Load;
            ResumeLayout(false);
        }
        //private void InitializeComponent()
        //{
        //    SuspendLayout();
        //    // 
        //    // CajaForm
        //    // 
        //    AutoScaleDimensions = new SizeF(13F, 32F);
        //    AutoScaleMode = AutoScaleMode.Font;
        //    ClientSize = new Size(800, 450);
        //    Name = "CajaForm";
        //    Text = "CajaForm";
        //    Load += CajaForm_Load;
        //    ResumeLayout(false);
        //}

        #endregion
    }
}