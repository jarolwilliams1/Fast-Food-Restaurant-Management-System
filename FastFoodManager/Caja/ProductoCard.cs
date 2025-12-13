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
    public partial class ProductoCard : UserControl
    {
        public ProductoCard()
        {
            InitializeComponent();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Nombre { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal Precio { get; set; }

        public event Action<string, decimal> OnAgregar;

        public ProductoCard(string nombre, decimal precio)
        {
            InitializeComponent();
            Nombre = nombre;
            Precio = precio;

            lblNombre.Text = nombre;
            lblPrecio.Text = precio.ToString("C2");
        }

        private void ProductoCard_Click(object sender, EventArgs e)
        {
            OnAgregar?.Invoke(Nombre, Precio);
        }

        private void ProductoCard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
