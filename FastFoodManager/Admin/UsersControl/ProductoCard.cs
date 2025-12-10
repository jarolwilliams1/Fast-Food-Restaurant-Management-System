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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Nombre { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal Precio { get; set; }
        public event Action<string, decimal> OnAgregar;
        public ProductoCard(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
            OnAgregar = OnAgregar;
            lblNombre.Text = nombre;
            lblPrecio.Text = precio.ToString("C2");
        }
        public ProductoCard(string nombre, decimal precio,  Action<string, decimal> onAgregar)
        {
            InitializeComponent();
            Nombre = nombre;
            Precio = precio;
            OnAgregar = onAgregar;
            lblNombre.Text = nombre;
            lblPrecio.Text = precio.ToString("C2");
        }

       

        private void ProductoCard_Load(object sender, EventArgs e)
        {
            OnAgregar?.Invoke(Nombre, Precio);

        }
    }
}
