using FastFoodManagerApp.Services;
using FastFoodManagerPlataformDomain.Entites;
using System;
using System.Windows.Forms;

namespace Menu
{
    public partial class Menus : Form
    {
        private readonly IProductoService _productoService;
        private readonly ICajaService _cajaService;
        private readonly IPedidoService _pedidoService; // ✅ NUEVO
        private readonly int _empleadoLogueadoId;

        // Constructor actualizado con el servicio de pedidos
        public Menus(IProductoService productoService, ICajaService cajaService, IPedidoService pedidoService, int empleadoId)
        {
            InitializeComponent();
            AutoScroll = true;
            _productoService = productoService;
            _cajaService = cajaService;
            _pedidoService = pedidoService; // ✅ NUEVO
            _empleadoLogueadoId = empleadoId;
        }

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
            //  Ahora inyecta el servicio de pedidos
            var GestionPedidos = new Pedidos( _pedidoService);
            GestionPedidos.Show();
        }

        private void Menus_Load(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var GestionProductos = new Productos(_productoService);
            GestionProductos.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            int clienteId = 1;
            CajaForm cajaForm = new CajaForm(_cajaService, _empleadoLogueadoId, clienteId);
            cajaForm.Show();
        }
    }
}