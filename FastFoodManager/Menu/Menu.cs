
//using Menu;

using FastFoodPlataformPersistencia.Context;
using FastFoodPlataformPersistencia.Repositories;

namespace Menu
{
    public partial class Menus : Form
    {
        private readonly ProductRepository _productRepository = null!;
        public Menus(ProductRepository repo)
        {
            InitializeComponent();
            AutoScroll = true;
            _productRepository = repo;
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

        private void label4_Click(object sender, EventArgs e)
        {
          var GestionProductos = new Productos(_productRepository);
            GestionProductos.Show();
        }
    }
}
