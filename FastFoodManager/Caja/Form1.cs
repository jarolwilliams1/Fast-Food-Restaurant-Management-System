
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Context;



namespace Caja
{

    public partial class Form1 : Form
    {
        private ProductRepository _productoRepo;

        // private readonly MenuServices _productsService;

        private readonly FastFoodManagerDBContext _context;
        public Form1()
        {
            _context = new FastFoodManagerDBContext();
            _productoRepo = new ProductoRepository();

            InitializeComponent();
            flowProductos.AutoScroll = true;
            flowCarrito.AutoScroll = true;
            flowProductos.WrapContents = true; // para que se acomoden

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void flowProductos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowCarrito_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AgregarAlCarrito();
            //EliminarItemCarrito();
            CargarProductos();


        }

        private void EliminarItemCarrito(CarritoItem item)
        {
            flowCarrito.Controls.Remove(item);
        }
        private void AgregarAlCarrito(string nombre, decimal precio)
        {
            // Ver si ya existe
            foreach (CarritoItem item in flowCarrito.Controls)
            {
                if (item.Nombre == nombre)
                {
                    item.Cantidad++;
                    return;
                }
            }

            // Crear item nuevo
            var nuevo = new CarritoItem(nombre, precio);
            nuevo.OnEliminar += EliminarItemCarrito;
            flowCarrito.Controls.Add(nuevo);
        }


        private void CargarProductos()
        {
            var productos = _context.Productos.ToList();

            foreach (var p in productos)
            {
                var card = new ProductoCard(p.Nombre, p.Precio);
                card.OnAgregar += AgregarAlCarrito;
                flowProductos.Controls.Add(card);
            }
        }

    }
}
