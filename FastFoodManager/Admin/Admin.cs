namespace Admin
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Bcaja_Click(object sender, EventArgs e)
        {
            //groupBoxMenu.Parent = this;
            groupBoxCaja.Visible = !groupBoxCaja.Visible;
            Bcaja.BackColor = label1.ForeColor;

            if (!groupBoxCaja.Visible)
            {
                Bcaja.BackColor = label1.BackColor;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxCaja_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bMenu_Click(object sender, EventArgs e)
        {
            //groupBoxMenu.Parent = this;
            groupBoxMenu.Visible = !groupBoxMenu.Visible;
            bMenu.BackColor = label1.ForeColor;

            if (!groupBoxMenu.Visible)
            {
                bMenu.BackColor = label1.BackColor;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }
    }
}
