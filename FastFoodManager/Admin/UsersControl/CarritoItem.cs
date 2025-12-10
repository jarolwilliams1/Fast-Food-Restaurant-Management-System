using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin.UsersControl
{
    public partial class CarritoItem : UserControl
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; } = 1;

        public event Action<CarritoItem> OnEliminar;

        public CarritoItem(string nombre, decimal precio)
        {
            InitializeComponent();
            Nombre = nombre;
            Precio = precio;

            lblNombre.Text = nombre;
            lblPrecioUnit.Text = precio.ToString("C2");
            lblCantidad.Text = Cantidad.ToString();
            lblTotal.Text = (Cantidad * Precio).ToString("C2");
        }

        private void CarritoItem_Load(object sender, EventArgs e)
        {

        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            Cantidad++;
            ActualizarTotal();
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (Cantidad > 1) Cantidad--;
            ActualizarTotal();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OnEliminar?.Invoke(this);
        }

        private void ActualizarTotal()
        {
            lblCantidad.Text = Cantidad.ToString();
            lblTotal.Text = (Cantidad * Precio).ToString("C2");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

    //public partial class CarritoItem : UserControl
    //{
    //    public CarritoItem()
    //    {
    //        InitializeComponent();
    //    }


}


