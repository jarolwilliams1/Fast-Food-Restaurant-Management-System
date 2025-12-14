using System;
using System.Windows.Forms;
using FastFoodManagerApp.Services;

namespace Menu
{
    public partial class Menus : Form
    {
        // ✅ CORRECTO: Usar SERVICIOS, no repositorios
        private readonly IProductoService _productoService;
        private readonly ICajaService _cajaService;
        private readonly int _empleadoLogueadoId;

        // Constructor con inyección de dependencias de SERVICIOS
        public Menus(IProductoService productoService, ICajaService cajaService, int empleadoId)
        {
            InitializeComponent();
            AutoScroll = true;
            _productoService = productoService;
            _cajaService = cajaService;
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
            // Aquí también deberías inyectar el servicio de pedidos
            // Por ahora lo dejamos así si no lo tienes implementado
            var GestionPedidos = new Pedidos();
            GestionPedidos.Show();
        }

        private void Menus_Load(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // ✅ CORRECTO: Pasar el servicio, no el repositorio
            var GestionProductos = new Productos(_productoService);
            GestionProductos.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // ✅ CORRECTO: Pasar todos los parámetros necesarios
            int clienteId = 1; // Cliente genérico para ventas de mostrador

            CajaForm cajaForm = new CajaForm(_cajaService, _empleadoLogueadoId, clienteId);
            cajaForm.Show(); // Para abrir como ventana independiente
        }
    }
}