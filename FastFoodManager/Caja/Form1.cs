
using FastFoodManagerPlataformDomain.Interfaces;
using System.Reflection;
//using FastFoodPlataformPersistencia.Context;



namespace Caja
{

    public partial class Form1 : Form
    {
        private UserControl[,] productos = new UserControl[2,2];
        public UserControl[,] carrito = new UserControl[1, 1];

        private Button[,] botones = new Button[2,2] ; // se crea una matriz
       // private ProductRepository _productoRepo;

        // private readonly MenuServices _productsService;

       // private readonly FastFoodManagerDBContext _context;
        public Form1()
        {
            //_context = new FastFoodManagerDBContext();
            //_productoRepo = new ProductoRepository();

            InitializeComponent();
            flowProductos.AutoScroll = true;
            flowCarrito.AutoScroll = true;
            flowProductos.WrapContents = true; // para que se acomoden

        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("presion");

        }

        private void flowProductos_Paint(object sender, PaintEventArgs e)
        {

            for (int f = 0; f < productos.GetLength(0); f++)// cada for es para iterar columnas y filas
            {

                for (int c = 0; c < productos.GetLength(1); c++)
                {
                    productos[f, c] = new UserControl(); // se instancia un objeto
                    //productos[f, c].Location = new Point(f * 50, c * 50); // pisicion 
                    // productos[f, c].Size = new Size (50, 50); // size
                    productos[f, c].Click += label2_Click; // evento
                    Controls.Add(productos[f, c]);

                }
            }
        }

        private void flowCarrito_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AgregarAlCarrito();
            //EliminarItemCarrito();
           // CargarProductos();


        }

   
    }
}
