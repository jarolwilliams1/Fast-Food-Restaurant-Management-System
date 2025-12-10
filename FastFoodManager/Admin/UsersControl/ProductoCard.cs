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
    public partial class ProductoCard : UserControl
    {
        public string Nombre { get; set; }
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

        private void ProductoCard_Load(object sender, EventArgs e)
        {
            OnAgregar?.Invoke(Nombre, Precio);

        }
    }
}
