

using Caja;
using FastFoodManagerApp.Services;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Context;
using Menu;
using Microsoft.EntityFrameworkCore;
namespace CajaPresencial
{
    public partial class Form1 : Form
    {

        private string nombre { get; set; }
        private int precio { get; set; }
        private readonly FastFoodManagerDBContext _dbContext;

        private Flowproductocard[,] Productocard = new Flowproductocard[5, 5];

        private CarritoItem[,] carriToitem = new CarritoItem[1, 1];

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {


            int cantidad = 0;

            using (var context = new FastFoodManagerDBContext())
            {
                cantidad = (int)context.Productos.Count();
            }
            Productocard = new Flowproductocard[cantidad, cantidad];




            for (int f = 0; f < Productocard.GetLength(0); f++)
            {
                for (int c = 0; c < Productocard.GetLength(1); c++)
                {
                    Productocard[f, c] = new Flowproductocard(nombre, precio);
                    Productocard[f, c].Location = new Point(100, 100);
                    Productocard[f, c].Size = new Size(520, 211);
                    Productocard[f, c].Margin = new Padding(20, 20, 20, 20);
                    //Productocard[f, c].Click += ;
                    Controls.Add(Productocard[f, c]);

                }
            }

        }

        private void EliminarItemCarrito(flowCarrito item)
        {
           // Flowproductocard.Controls.Remove(item);
        }
        private void AgregarAlCarrito(string nombre, decimal precio, Flowproductocard flowproductocard)
        {
            // Ver si ya existe
            foreach (flowCarrito item in flowproductocard.Controls)
            {
                if (item.Nombre == nombre)
                {
                    item.Cantidad++;
                    return;
                }
            }

            // Crear item nuevo
            var nuevo = new flowCarrito(nombre, precio);
            nuevo.OnEliminar += EliminarItemCarrito;
            //flproduct.Controls.Add(nuevo);
        }


        public void CargarProductos(Flowproductocard flowproductocard)
        {
            var productos = _dbContext.Productos.ToList();

            foreach (var p in productos)
            {
                var card = new Flowproductocard(p.Nombre, p.Precio);
               // card.OnAgregar += AgregarAlCarrito;
                flowproductocard.Controls.Add(card);
            }
        }

        private void flowCarrito_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;
        }
    }
}
