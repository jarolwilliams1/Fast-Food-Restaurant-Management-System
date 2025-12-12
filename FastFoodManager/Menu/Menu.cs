
//using Menu;

namespace Menu
{
    public partial class Menus : Form
    {
        public Menus()
        {
            InitializeComponent();
            AutoScroll = true;
        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Gpedidos_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            var GestionPedidos = new Pedidos();
            GestionPedidos.Show();
        }

        private void Menus_Load(object sender, EventArgs e)
        {

        }
    }
}
