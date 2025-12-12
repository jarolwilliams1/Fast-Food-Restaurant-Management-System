using Admin.UsersControl;
using Microsoft.EntityFrameworkCore;
//using FastFoodManagerDBContext.context;
//using FastFoodPlataformPersistencia.Context;


namespace Admin
{
    public partial class Form1 : Form
    {
      // private readonly FastFoodManagerDBContext _dbContext;
        public Form1()
        {
            InitializeComponent();
            flowProductos.AutoScroll = true; // Activa la barra de desplazamiento cuando los elementos sobrepasan el tamaño del panel.
            flowCarrito.AutoScroll = true;
            flowProductos.WrapContents = true; // para que se acomoden
        }
       private void Form1_Load(object sender, EventArgs e) {}


      
 
    
       
        
       


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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void flowCarrito_Paint(object sender, PaintEventArgs e)
        {
            

        }
    }
}

