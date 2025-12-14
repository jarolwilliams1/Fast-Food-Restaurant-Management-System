using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Context;
using Microsoft.EntityFrameworkCore;
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
    public partial class Flowproductocard : UserControl
    {
        private readonly FastFoodManagerDBContext _dbContext;

        //public FlowProductoCard()
        //{
        //    InitializeComponent();

        //}
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Nombre { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal Precio { get; set; }

        public event Action<string, decimal> OnAgregar;

        public Flowproductocard(string nombre, decimal precio )
        {
            InitializeComponent();
            Nombre = nombre;
            //Precio = precio;
            //FlowProductoCard.AutoScroll = true;
            //flowCarrito.AutoScroll = true;
            //FlowProductoCard.WrapContents = true; 


                        lblNombre.Text = nombre;
            lblPrecio.Text = precio.ToString("C2");
        }

        private void ProductoCard_Click(object sender, EventArgs e)
        {
            OnAgregar?.Invoke(Nombre, Precio);
        }

        private void ProductoCard_Load(object sender, EventArgs e)
        {
            //Flowproductocard.AutoScroll = true;
            //Flowproductocard.AutoScroll = true;
            //Flowproductocard.WrapContents = true; 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void EliminarItemCarrito(FlowLayoutPanel flowCarrito, flowCarrito item)
        {
            flowCarrito.Controls.Remove(item);
        }

        private void AgregarAlCarrito(string nombre, decimal precio, FlowLayoutPanel FlowProductoCard, FlowLayoutPanel flowCarrito)
        {
            // Ver si ya existe
            foreach (flowCarrito item in FlowProductoCard.Controls)
            {
                if (item.Nombre == nombre)
                {
                    item.Cantidad++;
                    return;
                }
            }

            // Crear item nuevo
            var nuevo = new flowCarrito(nombre, precio);
           // nuevo.OnEliminar += EliminarItemCarrito;
            flowCarrito.Controls.Add(nuevo);
        }
        private void CargarProductos(FlowLayoutPanel FlowProductoCard)
        {
            var productos = _dbContext.Productos.ToList();

            foreach (var p in productos)
            {
                var card = new Flowproductocard(p.Nombre, p.Precio);
              // card.OnAgregar += AgregarAlCarrito;
                FlowProductoCard.Controls.Add(card);
            }
        }
    }
}
