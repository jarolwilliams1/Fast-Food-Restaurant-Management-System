using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caja
{
    public partial class flowCarrito : UserControl
    {
        public flowCarrito()
        {
            InitializeComponent();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Nombre { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal Precio { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Cantidad { get; set; } = 1;

        public event Action<flowCarrito> OnEliminar;

        public flowCarrito(string nombre, decimal precio)
        {
            InitializeComponent();
            Nombre = nombre;
            Precio = precio;

            lblNombre.Text = nombre;
            lblPrecioUnit.Text = precio.ToString("C2");
            lblCantidad.Text = Cantidad.ToString();
            lblTotal.Text = (Cantidad * Precio).ToString("C2");
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

        private void CarritoItem_Load(object sender, EventArgs e)
        {

        }
      
    }
}
